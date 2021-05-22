using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;
using FlaskParameters;

namespace Flask
{
    /// <summary>
    /// Класс построителя модели фляжки.
    /// </summary>
    public class ModelBuilder
    {
        /// <summary>
        /// Указатель на экземпляр компаса.
        /// </summary>
        private KompasObject _kompas;

        /// <summary>
        /// Указатель на экземпляр документа.
        /// </summary>
        private ksDocument3D _ksDoc3D;

        /// <summary>
        /// Указатель на эскиз.
        /// </summary>
        private ksDocument2D _ksSketchEdit;

        /// <summary>
        /// Указатель на интерфейс компонента.
        /// </summary>
        private ksPart _ksPart;

        /// <summary>
        /// Указатель на интерфейс сущности.
        /// </summary>
        private ksEntity _entitySketch;

        /// <summary>
        /// Указатель на интерфейс параметров эскиза.
        /// </summary>
        private ksSketchDefinition _ksSketchDefinition;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="parameters">Параметры фляжки.</param>
        /// <param name="kompas">Интерфейс API компаса.</param>
        public void BuildFlask(Parameters parameters, KompasObject kompas)
        {
            _kompas = kompas;
            _ksDoc3D = (ksDocument3D)_kompas.Document3D();
            _ksDoc3D.Create();
            _ksDoc3D = (ksDocument3D)_kompas.ActiveDocument3D();
            _ksPart = (ksPart)_ksDoc3D.GetPart((short)Part_Type.pTop_Part);

            CreateBody(parameters.FlaskLength, parameters.FlaskWidth,
                parameters.FlaskHeight, parameters.CaseThickness,
                parameters.NeckDiameter, parameters.NeckHeight);
            CreateThread(parameters.FlaskWidth, parameters.NeckDiameter, 
                parameters.FlaskHeight + parameters.NeckHeight, 
                parameters.NeckDiameter, parameters.NeckHeight - 1, 
                parameters.FlaskWidth);
        }

        /// <summary>
        /// Создание основы корпуса фляжки.
        /// </summary>
        /// <param name="flaskLength">Длина фляжки</param>
        /// <param name="flaskWidth">Ширина фляжки</param>
        /// <param name="flaskHeight">Высота фляжки</param>
        /// <param name="caseThickness">Толщина оболочки</param>
        /// <param name="neckDiameter">Диаметр горлышка</param>
        /// <param name="neckHeight">Высота горлышка</param>
        private void CreateBody(double flaskLength, double flaskWidth, 
            double flaskHeight, double caseThickness, double neckDiameter, 
            double neckHeight)
        {
            var currentPlane = (ksEntity)_ksPart.GetDefaultEntity(
                (short)Obj3dType.o3d_planeXOY);
            var corner = flaskWidth / 2;
            var offsetPlaneXoy = CreateOffsetPlane(flaskHeight, 1);
            CreateRectangle(flaskLength, flaskWidth, 0, 0, currentPlane, 
                flaskWidth / 2);
            Extrude(flaskHeight, _entitySketch);
            CreareCircle(0, flaskWidth / 2, neckDiameter / 2, offsetPlaneXoy);
            Extrude(neckHeight, _entitySketch);
            CreateShell(caseThickness);
        }

        /// <summary>
        /// Создать прямоугольник.
        /// </summary>
        /// <param name="length">Длина прямоугольника</param>
        /// <param name="width">Ширина прямоугольника.</param>
        /// <param name="x">Координата базовой точки x пря­моугольника.</param>
        /// <param name="y">Координата базовой точки у пря­моугольника.</param>
        /// <param name="currentPlane">Плость прямоугольника.</param>
        /// <param name="corner">Радиус скругления угла</param>
        private void CreateRectangle(double length, double width, double x, 
            double y, ksEntity currentPlane, double corner)
        {
            CreateSketch(currentPlane);
            _ksSketchEdit = (ksDocument2D)_ksSketchDefinition.BeginEdit();
            var param = (ksRectangleParam)_kompas.GetParamStruct(
                (short)StructType2DEnum.ko_RectangleParam);
            param.ang = 0;
            param.height = length;
            param.width = width;
            param.style = 1;
            param.x = -width/2;
            param.y = y;
            var corners = RoundingCorners(param, corner);
            _ksSketchEdit.ksRectangle(param);
            _ksSketchDefinition.EndEdit();
        }

        /// <summary>
        /// Создать окружность.
        /// </summary>
        /// <param name="xc">Координата x центра окружности.</param>
        /// <param name="yc">Координата у центра окружности.</param>
        /// <param name="radius">Радиус окружности.</param>
        /// <param name="currentPlane">Плоскость окружности.</param>
        private void CreareCircle(double xc, double yc, double radius, 
            ksEntity currentPlane)
        {
            CreateSketch(currentPlane);
            _ksSketchEdit = (ksDocument2D)_ksSketchDefinition.BeginEdit();
            _ksSketchEdit.ksCircle(xc, yc, radius, 1);
            _ksSketchDefinition.EndEdit();
        }
        
        /// <summary>
        /// Создать оболочку.
        /// </summary>
        /// <param name="thickness">Толщина оболочки.</param>
        private void CreateShell(double thickness)
        {
            var entityCollectionPart =
                (ksEntityCollection)_ksPart.EntityCollection(
                (short)Obj3dType.o3d_face);
            var entityShell = (ksEntity)_ksPart.NewEntity(
                (short)Obj3dType.o3d_shellOperation);
            var shellDefinition =
                (ksShellDefinition)entityShell.GetDefinition();
            shellDefinition.thickness = thickness;
            shellDefinition.thinType = true;
            shellDefinition.FaceArray();
            var entityCollectionShell = (
                ksEntityCollection)shellDefinition.FaceArray();
            entityCollectionShell.Clear();
            entityCollectionShell.Add(entityCollectionPart.GetByIndex(6));
            entityShell.Create();
        }

        /// <summary>
        /// Создание новой плоскости.
        /// </summary>
        /// <param name="offset">Расстояние до плоскости.</param>
        /// <param name="plane">Смещаемая плоскость.</param>
        /// <returns></returns>
        private ksEntity CreateOffsetPlane(double offset, short plane)
        {
            var newPlane = (ksEntity)_ksPart.NewEntity(
                (short)Obj3dType.o3d_planeOffset);
            var newPlaneDefinition = (
                ksPlaneOffsetDefinition)newPlane.GetDefinition();
            newPlaneDefinition.SetPlane((ksEntity)_ksPart.GetDefaultEntity(plane));
            newPlaneDefinition.direction = true;
            newPlaneDefinition.offset = offset;
            newPlane.Create();
            newPlane.hidden = true;
            return newPlane;
        }

        /// <summary>
        /// Скругление углов.
        /// </summary>
        /// <param name="param">Свойства прямоугольника.</param>
        /// <param name="corner">Радиус угла.</param>
        /// <returns></returns>
        private ksDynamicArray RoundingCorners(ksRectangleParam param, double corner)
        {
            var corners = (ksDynamicArray)param.GetPCorner();
            var cornerParams = (ksCornerParam)_kompas.GetParamStruct(
                (short)StructType2DEnum.ko_CornerParam);
            cornerParams.Init();
            for (var i = 0; i < 4; i++)
            {
                cornerParams.index = i + 1;
                cornerParams.fillet = true;
                cornerParams.l1 = corner;
                cornerParams.l2 = corner;
                corners.ksAddArrayItem(-1, cornerParams);
            }
            return corners;
        }
        
        /// <summary>
        /// Создать эскиз.
        /// </summary>
        /// <param name="currentPlane">Плоскость эскиза.</param>
        private void CreateSketch(ksEntity currentPlane)
        {
            _entitySketch = (ksEntity)_ksPart.NewEntity(
                (short)Obj3dType.o3d_sketch);
            _ksSketchDefinition = (ksSketchDefinition)_entitySketch.GetDefinition();
            _ksSketchDefinition.SetPlane(currentPlane);
            _entitySketch.Create();
        }

        /// <summary>
        /// Выдавливание.
        /// </summary>
        /// <param name="depth">Глубина выдавливания.</param>
        /// <param name="entitySketch">Указатель на интерфейс сущности.</param>
        private void Extrude(double depth, object entitySketch)
        {
            _entitySketch = (ksEntity)_ksPart.NewEntity(
                (short)Obj3dType.o3d_sketch);
            var entityExtrude = (ksEntity)_ksPart.NewEntity(
               (short)Obj3dType.o3d_baseExtrusion);
            var entityExtrudeDefinition = (
                ksBaseExtrusionDefinition)entityExtrude.GetDefinition();
            entityExtrudeDefinition.SetSideParam(true, 0, depth);
            entityExtrudeDefinition.SetSketch(entitySketch);
            entityExtrude.Create();
        }

        /// <summary>
        /// Создать резьбу.
        /// </summary>
        /// <param name="offsetPlane">Расстояние до плоскости резьбы.</param>
        /// <param name="offsetX">Координата базовой точки x.</param>
        /// <param name="offsetZ">Координата базовой точки z.</param>
        /// <param name="diameter">Диаметер резьбы.</param>
        /// <param name="height">Высота резьбы.</param>
        /// <param name="width">Ширина фляжки.</param>
        private void CreateThread(double offsetPlane, double offsetX, double offsetZ,
            double diameter, double height, double width)
        {
            CreateTriangle(offsetPlane, offsetX, offsetZ);
            CreateSpiral(height, diameter, offsetZ, width);
        }

        /// <summary>
        /// Создать треугольник.
        /// </summary>
        /// <param name="offsetPlane">Расстояние до плоскости треугольника.</param>
        /// <param name="offsetX">Координата базовой точки x треугольника.</param>
        /// <param name="offsetZ">Координата базовой точки z треугольника.</param>
        private void CreateTriangle(double offsetPlane, double offsetX, double offsetZ)
        {
            var offsetPlaneXoz = CreateOffsetPlane(offsetPlane / 2, 2);
            CreateSketch(offsetPlaneXoz);
            _ksSketchEdit = (ksDocument2D)_ksSketchDefinition.BeginEdit();
            var param = (ksRegularPolygonParam)_kompas.GetParamStruct(
                (short)StructType2DEnum.ko_RegularPolygonParam);
            param.count = 3;
            param.xc = offsetX / 2 - 0.2;
            param.yc = - offsetZ;
            param.radius = 0.2;
            param.describe = true;
            param.style = 1;
            _ksSketchEdit.ksRegularPolygon(param, 0);
            _ksSketchDefinition.EndEdit();
        }

        /// <summary>
        /// Создать спираль.
        /// </summary>
        /// <param name="height">Высота спирали.</param>
        /// <param name="diameter">Диаметр спирали.</param>
        /// <param name="offset">Расстояние до плоскости.</param>
        /// <param name="width">Координата смещения спирали.</param>
        private void CreateSpiral(double height, double diameter, double offset, 
            double width)
        {
            var offsetPlaneXoy = CreateOffsetPlane(offset, 1);
            var cylindricSpiral = (ksEntity)_ksPart.
               NewEntity((short)Obj3dType.o3d_cylindricSpiral);
            var param =
                (ksCylindricSpiralDefinition)cylindricSpiral.GetDefinition();
            param.buildDir = false;
            param.buildMode = 2;
            param.diam = diameter;
            param.step = height - 1;
            param.height = height;
            param.SetPlane(offsetPlaneXoy);
            cylindricSpiral.Create();
            param.SetLocation(0, width / 2);
            cylindricSpiral.Update();
            CutRotate(_entitySketch, cylindricSpiral);
        }

        /// <summary>
        /// Операция "Элемент по траектории"
        /// </summary>
        /// <param name="entitySketch">Указатель на интерфейс сущности.</param>
        /// <param name="path">Траектория выдавливания.</param>
        private void CutRotate (object entitySketch, ksEntity path)
        {
            var entityCutEvolution = _ksPart.
                            NewEntity((short)Obj3dType.o3d_cutEvolution);
            var param =
                (ksCutEvolutionDefinition)entityCutEvolution.GetDefinition();
            param.cut = true;
            param.SetThinParam(false);
            param.SetSketch(entitySketch);
            var pathArray = param.PathPartArray();
            pathArray.Add(path);
            entityCutEvolution.Create();
        }
    }
}

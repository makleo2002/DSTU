package first.java;

import javafx.application.Application;

import javafx.geometry.Point3D;
import javafx.scene.Group;
import javafx.scene.Scene;
import javafx.scene.paint.Color;
import javafx.scene.paint.PhongMaterial;
import javafx.scene.shape.Cylinder;
import javafx.scene.shape.Sphere;
import javafx.scene.transform.Rotate;
import javafx.scene.transform.Translate;
import javafx.stage.Stage;

import java.io.BufferedReader;
import java.io.FileReader;

public class Task6 extends Application {
    public void start(Stage stage) throws Exception {
        Group molecule=new Group();
        Scene scene = new Scene(molecule, 450, 400);
        double r=50;
        Sphere m1=new Sphere(r);
        Sphere m2=new Sphere(r);
        Color curColor= Color.rgb(0xb3,0x66,0x1a,1);
        m1.setMaterial(new PhongMaterial(curColor));
        m2.setMaterial(new PhongMaterial(curColor));
        m1.setTranslateX(100); m2.setTranslateX(300);
        m1.setTranslateY(100); m2.setTranslateY(100);
        m1.setTranslateZ(0); m2.setTranslateZ(0);
/* можно задать режим рисования: сплошной (по умолчанию), каркас
из линий (LINE) */
// m2.drawModeProperty().set(DrawMode.LINE);
        double h = 200-2*r+4; // высота цилиндра, соединяющего сферы
        Cylinder cyl1 = new Cylinder(r/3,h);
        cyl1.setMaterial(new PhongMaterial(curColor));
        cyl1.setTranslateX(100+2*r);
        cyl1.setTranslateY(100);
        cyl1.setTranslateZ(0);
        cyl1.setRotate(90); // изначально цилиндр расположен вертикально
        molecule.getChildren().addAll(m1, m2, cyl1);
        double xAngle = 20, yAngle = 33, zAngle = 45;
        javafx.scene.transform.Rotate xRotate = new Rotate(0, Rotate.X_AXIS);
        Rotate yRotate = new Rotate(0,Rotate.Y_AXIS);
        Rotate zRotate = new Rotate(0,Rotate.Z_AXIS);
        xRotate.setAngle(xAngle);
        yRotate.setAngle(yAngle);
        zRotate.setAngle(zAngle);
        BufferedReader reader=new BufferedReader(new FileReader("src/main/resources/files/xyz.txt"));
        String s;
        String str= "";
        String elem="";
        int sphere_cnt;
    while(reader.ready()){
        s = reader.readLine();
        char[] array=s.toCharArray();
        for(int i:array){
            if(i=='\n') str+="\n";
        }
        str+=s;
        System.out.println(s);
    }
    sphere_cnt=str.charAt(0);

        System.out.println(str);

        stage.setTitle("3D molecule");
        stage.setScene(scene);
        stage.show();
    }
    public Cylinder createConnection(Point3D origin, Point3D target) {
        Point3D yAxis = new Point3D(0, 1, 0); /* цилиндр изначально расположен вертикально
(высота вдоль оси OY), направляющий вектор для оси OY - (0, 1, 0) */
        Point3D diff = target.subtract(origin); /* разность векторов target и origin - вектор,
направленный от origin к target */
        double height = diff.magnitude(); // расстояние между origin и target - высота цилиндра
        Point3D mid = target.midpoint(origin); /* точка, лежащая посередине между target и
origin - сюда нужно переместить цилиндр (поместить его центр) */
        Translate moveToMidpoint = new Translate(mid.getX(), mid.getY(), mid.getZ());
        Point3D axisOfRotation = diff.crossProduct(yAxis); /* ось, вокруг которой нужно
повернуть цилиндр - направлена перпендикулярно плоскости, в которой лежат
пересекающиеся вектора diff (направление от origin к target) и yAxis (текущее направление
высоты цилиндра), получается как векторное произведение diff и yAxis */
        double angle = Math.acos(diff.normalize().dotProduct(yAxis)); /* угол поворота цилиндра -
угол между нормализованным (длина равна 1) вектором diff и вектором yAxis */
        Rotate rotateAroundCenter = new Rotate(-Math.toDegrees(angle), axisOfRotation);
        Cylinder line = new Cylinder(1, height); /* радиус цилиндра 1, нужно заменить на свое
значение */
        line.getTransforms().addAll(moveToMidpoint, rotateAroundCenter);
        return line;
    }
    public static void main(String[] args) {
        launch();
    }
}
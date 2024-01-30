package first.java;

import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.input.KeyCode;
import javafx.scene.layout.Pane;
import javafx.scene.paint.Color;
import javafx.scene.shape.Circle;
import javafx.scene.shape.Ellipse;
import javafx.scene.shape.Line;
import javafx.scene.shape.Rectangle;
import javafx.stage.Stage;

import java.io.IOException;

public class Task2 extends Application {
    public void start(Stage stage) throws IOException {
        Pane root=new Pane();
        Scene scene = new Scene(root, 480, 400);

        switch((int) (1+Math.random()*4)){
            case(1):
                Line line=new Line(200,160,280,240);
                line.setStroke(Color.GREEN);
                line.setFill(Color.LIGHTGREEN);
                Rectangle rect1=new Rectangle(80,80);
                rect1.setLayoutX(200);
                rect1.setLayoutY(160);
                rect1.getStrokeDashArray().setAll(10.0,5.0);
                rect1.setStroke(Color.GRAY);
                rect1.setFill(Color.WHITE);
                root.getChildren().add(rect1);
                root.getChildren().add(line);
                break;
            case(2):
                Circle circle=new Circle(80);
                circle.setLayoutX(200);
                circle.setLayoutY(160);
                circle.setStroke(Color.GREEN);
                circle.setFill(Color.LIGHTGREEN);
                Rectangle rect2=new Rectangle(160,160);
                rect2.setLayoutX(120);
                rect2.setLayoutY(80);
                rect2.getStrokeDashArray().setAll(10.0,5.0);
                rect2.setStroke(Color.GRAY);
                rect2.setFill(Color.WHITE);
                root.getChildren().add(rect2);
                root.getChildren().add(circle);
                break;
            case(3):
                Ellipse ellipse=new Ellipse(80,100);
                ellipse.setLayoutX(200);
                ellipse.setLayoutY(160);
                ellipse.setStroke(Color.GREEN);
                ellipse.setFill(Color.LIGHTGREEN);
                Rectangle rect3=new Rectangle(160,200);
                rect3.setLayoutX(120);
                rect3.setLayoutY(60);
                rect3.getStrokeDashArray().setAll(10.0,5.0);
                rect3.setStroke(Color.GRAY);
                rect3.setFill(Color.WHITE);
                root.getChildren().add(rect3);
                root.getChildren().add(ellipse);
                break;
            case(4):
                Rectangle rectangle=new Rectangle(100,150);
                rectangle.setLayoutX(200);
                rectangle.setLayoutY(160);
                rectangle.setStroke(Color.GREEN);
                rectangle.setFill(Color.LIGHTGREEN);
                Rectangle rect4=new Rectangle(120,170);
                rect4.setLayoutX(190);
                rect4.setLayoutY(150);
                rect4.getStrokeDashArray().setAll(10.0,5.0);
                rect4.setStroke(Color.GRAY);
                rect4.setFill(Color.WHITE);
                root.getChildren().add(rect4);
                root.getChildren().add(rectangle);
                break;
        }
        var frame=root.getChildren().get(0);
        var figure=root.getChildren().get(1);
        

        scene.setOnKeyPressed(e->{
            if (e.getCode() == KeyCode.LEFT){
                frame.setLayoutX(frame.getLayoutX()-5);
                if(figure instanceof Line){
                    ((Line)figure).setStartX(((Line) figure).getStartX()-5);
                    ((Line)figure).setEndX(((Line) figure).getEndX()-5);
                }
                if(figure instanceof Rectangle){
                    (figure).setLayoutX(( figure).getLayoutX()-5);
                }
                if(figure instanceof Circle){
                    (figure).setLayoutX(( figure).getLayoutX()-5);
                }
                if(figure instanceof Ellipse){
                    (figure).setLayoutX(( figure).getLayoutX()-5);
                }
            }
            if (e.getCode() == KeyCode.RIGHT){

                frame.setLayoutX(frame.getLayoutX()+5);
                if(figure instanceof Line){
                    ((Line)figure).setStartX(((Line) figure).getStartX()+5);
                    ((Line)figure).setEndX(((Line) figure).getEndX()+5);
                }
                if(figure instanceof Rectangle){
                    (figure).setLayoutX(( figure).getLayoutX()+5);
                }
                if(figure instanceof Circle){
                    (figure).setLayoutX(( figure).getLayoutX()+5);
                }
                if(figure instanceof Ellipse){
                    (figure).setLayoutX(( figure).getLayoutX()+5);
                }
            }
            if (e.getCode() == KeyCode.UP){
                frame.setLayoutY(frame.getLayoutY()-5);
                if(figure instanceof Line){
                    ((Line)figure).setStartY(((Line) figure).getStartY()-5);
                    ((Line)figure).setEndY(((Line) figure).getEndY()-5);
                }
                if(figure instanceof Rectangle){
                    (figure).setLayoutY(( figure).getLayoutY()-5);
                }
                if(figure instanceof Circle){
                    (figure).setLayoutY(( figure).getLayoutY()-5);
                }
                if(figure instanceof Ellipse){
                    (figure).setLayoutY(( figure).getLayoutY()-5);
                }
            }
            if (e.getCode() == KeyCode.DOWN){
                frame.setLayoutY(frame.getLayoutY()+5);
                if(figure instanceof Line){
                    ((Line)figure).setStartY(((Line) figure).getStartY()+5);
                    ((Line)figure).setEndY(((Line) figure).getEndY()+5);
                }
                if(figure instanceof Rectangle){
                    (figure).setLayoutY((figure).getLayoutY()+5);
                }
                if(figure instanceof Circle){
                    (figure).setLayoutY((figure).getLayoutY()+5);
                }
                if(figure instanceof Ellipse){
                    (figure).setLayoutY((figure).getLayoutY()+5);
                }
            }
            if(e.getCode()==KeyCode.COMMA){
                ((Rectangle)frame).setWidth(((Rectangle)frame).getWidth()-5);
                if(figure.getClass()== Line.class){
                    ((Line)figure).setEndX(((Line) figure).getEndX()-5);
                }
                if(figure.getClass()==Rectangle.class){
                    ((Rectangle)figure).setWidth(((Rectangle) figure).getWidth()-5);
                }
                if(figure.getClass()==Circle.class){
                    ((Circle)figure).setRadius((((Circle)figure)).getRadius()-5);
                }
                if(figure.getClass()==Ellipse.class){
                    ((Ellipse)figure).setRadiusX(((Ellipse) figure).getRadiusX()-5);
                }
            }
            if(e.getCode()==KeyCode.PERIOD){
                ((Rectangle)frame).setWidth(((Rectangle)frame).getWidth()+5);
                if(figure instanceof Line){
                    ((Line)figure).setEndX(((Line) figure).getEndX()+5);
                }
                if(figure instanceof Rectangle){
                    ((Rectangle)figure).setWidth(((Rectangle) figure).getWidth()+5);
                }
                if(figure instanceof Circle){
                    ((Circle)figure).setRadius((( (Circle)figure)).getRadius()+5);
                }
                if(figure instanceof Ellipse){
                    ((Ellipse)figure).setRadiusX(((Ellipse) figure).getRadiusX()+5);
                }
            }
            if(e.getCode()==KeyCode.EQUALS){
                ((Rectangle)frame).setHeight(((Rectangle)frame).getHeight()+5);
                if(figure instanceof Line){
                    ((Line)figure).setEndY(((Line) figure).getEndY()+5);
                }
                if(figure instanceof Rectangle){
                    ((Rectangle)figure).setHeight(((Rectangle) figure).getHeight()+5);
                }
                if(figure instanceof Circle){
                    ((Circle)figure).setRadius((((Circle)figure)).getRadius()+5);
                }
                if(figure instanceof Ellipse){
                    ((Ellipse)figure).setRadiusY(((Ellipse) figure).getRadiusY()+5);
                }
            }
            if(e.getCode()==KeyCode.MINUS){
                ((Rectangle)frame).setHeight(((Rectangle)frame).getHeight()-5);
                if(figure instanceof Line){
                    ((Line)figure).setEndY(((Line) figure).getEndY()-5);
                }
                if(figure instanceof Rectangle){
                    ((Rectangle)figure).setHeight(((Rectangle) figure).getHeight()-5);

                }
                if(figure instanceof Circle){
                    ((Circle)figure).setRadius((((Circle)figure)).getRadius()-5);
                    ((Rectangle)frame).setWidth(((Rectangle)frame).getWidth()-5);
                }
                if(figure instanceof Ellipse){
                    ((Ellipse)figure).setRadiusY(((Ellipse) figure).getRadiusY()-5);
                }
            }
        });

        stage.setTitle("2D Primitives");
        stage.setScene(scene);
        stage.show();
    }
    public static void main(String[] args) {
        launch();
    }
}

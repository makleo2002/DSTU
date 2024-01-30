package first.java;

import javafx.application.Application;
import javafx.embed.swing.SwingFXUtils;
import javafx.scene.Node;
import javafx.scene.Scene;
import javafx.scene.SnapshotParameters;
import javafx.scene.canvas.Canvas;
import javafx.scene.control.*;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.image.WritableImage;
import javafx.scene.input.*;
import javafx.scene.layout.AnchorPane;
import javafx.scene.layout.Pane;
import javafx.scene.layout.VBox;
import javafx.scene.media.Media;
import javafx.scene.paint.Color;
import javafx.scene.shape.*;
import javafx.scene.text.Text;
import javafx.stage.FileChooser;
import javafx.stage.Stage;

import javax.imageio.ImageIO;
import java.io.File;
import java.io.IOException;
import java.io.InputStream;

public class Task3 extends Application {
    int cnt=0;
    public void start(Stage stage) throws IOException {
        Pane root=new Pane();
        Scene scene = new Scene(root, 700, 400);
        ToggleButton line_btn=new ToggleButton();
        ToggleButton rect_btn=new ToggleButton();
        ToggleButton circle_btn=new ToggleButton();
        ToggleButton ellipse_btn=new ToggleButton();



        InputStream iconstream1=getClass().getResourceAsStream("/images/img5.png");
        ImageView imageView1 = new ImageView(new Image(iconstream1));
        imageView1.setFitHeight(40);
        imageView1.setFitWidth(40);
        line_btn.setGraphic(imageView1);

        InputStream iconstream2=getClass().getResourceAsStream("/images/img6.png");
        ImageView imageView2 = new ImageView(new Image(iconstream2));
        imageView2.setFitHeight(40);
        imageView2.setFitWidth(40);
        rect_btn.setGraphic(imageView2);

        InputStream iconstream3=getClass().getResourceAsStream("/images/img7.png");
        ImageView imageView3 = new ImageView(new Image(iconstream3));
        imageView3.setFitHeight(40);
        imageView3.setFitWidth(40);
        circle_btn.setGraphic(imageView3);

        InputStream iconstream4=getClass().getResourceAsStream("/images/img8.png");
        ImageView imageView4 = new ImageView(new Image(iconstream4));
        imageView4.setFitHeight(40);
        imageView4.setFitWidth(40);
        ellipse_btn.setGraphic(imageView4);

        VBox pane1=new VBox();
        pane1.setPrefWidth(102);
        pane1.setPrefHeight(222);
        Text text1=new Text("Палитра");


        pane1.getChildren().addAll(text1,line_btn,rect_btn,circle_btn,ellipse_btn);

        line_btn.setLayoutX(31);
        line_btn.setLayoutX(33);

        rect_btn.setLayoutX(31);
        rect_btn.setLayoutX(81);

        circle_btn.setLayoutX(31);
        circle_btn.setLayoutX(129);

        ellipse_btn.setLayoutX(31);
        ellipse_btn.setLayoutX(176);

        AnchorPane pane=new AnchorPane(pane1);

       // pane.getChildren().add(pane1);
        pane.setPrefWidth(280);
        pane.setPrefHeight(380);

        pane.setLayoutX(400);
        pane.setLayoutY(23);
        pane1.setLayoutX(10);
        pane1.setLayoutY(30);

        Text text3=new Text("Ширина");
        Text text4=new Text("Высота");
        Text text5=new Text("Размер изображения pxl");
        TextField textField1=new TextField();
        textField1.setPrefWidth(60);
        textField1.setPrefHeight(25);
        TextField textField2=new TextField();
        textField2.setPrefWidth(60);
        textField2.setPrefHeight(25);
        AnchorPane pane2=new AnchorPane(text3,text4,text5,textField1,textField2);
        pane2.setLayoutX(10);
        pane2.setLayoutY(290);
        pane.getChildren().add(pane2);

        text3.setLayoutX(0);
        text3.setLayoutY(-5);

        text4.setLayoutX(0);
        text4.setLayoutY(25);

        text5.setLayoutX(0);
        text5.setLayoutY(-30);

        textField1.setLayoutX(50);
        textField1.setLayoutY(-20);

        textField2.setLayoutX(50);
        textField2.setLayoutY(10);

        MenuButton menuButton1=new MenuButton("#FFFFFF");
        MenuButton menuButton2=new MenuButton("#FFFFFF");
        Text text6=new Text("Цвет контура");
        Text text7=new Text("Цвет заливки");
        AnchorPane pane3=new AnchorPane(text6,text7,menuButton1,menuButton2);
        pane3.setPrefSize(142,139);
        pane3.setLayoutX(170);
        pane3.setLayoutY(40);

        menuButton1.setPrefSize(98,25);
        menuButton1.setLayoutX(-50);
        menuButton1.setLayoutY(15);

        MenuItem blue=new MenuItem("#0000FF");
        MenuItem red=new MenuItem("#FF0000");
        MenuItem yellow=new MenuItem("#FFFF00");
        MenuItem green=new MenuItem("#008000");
        MenuItem white=new MenuItem("#FFFFFF");
        MenuItem black=new MenuItem("#000000");
        MenuItem purple=new MenuItem("#800080");
        MenuItem orange=new MenuItem("#FFA500");
        MenuItem pink=new MenuItem("#FFC0CB");
        MenuItem gray=new MenuItem("#808080");

        MenuItem blue1=new MenuItem("#0000FF");
        MenuItem red1=new MenuItem("#FF0000");
        MenuItem yellow1=new MenuItem("#FFFF00");
        MenuItem green1=new MenuItem("#008000");
        MenuItem white1=new MenuItem("#FFFFFF");
        MenuItem black1=new MenuItem("#000000");
        MenuItem purple1=new MenuItem("#800080");
        MenuItem orange1=new MenuItem("#FFA500");
        MenuItem pink1=new MenuItem("#FFC0CB");
        MenuItem gray1=new MenuItem("#808080");

        blue.setOnAction(e->{menuButton1.setText(blue.getText());});
        red.setOnAction(e->{menuButton1.setText(red.getText());});
        yellow.setOnAction(e->{menuButton1.setText(yellow.getText());});
        green.setOnAction(e->{menuButton1.setText(green.getText());});
        white.setOnAction(e->{menuButton1.setText(white.getText());});
        black.setOnAction(e->{menuButton1.setText(black.getText());});
        purple.setOnAction(e->{menuButton1.setText(purple.getText());});
        orange.setOnAction(e->{menuButton1.setText(orange.getText());});
        pink.setOnAction(e->{menuButton1.setText(pink.getText());});
        gray.setOnAction(e->{menuButton1.setText(gray.getText());});

        blue1.setOnAction(e->{menuButton2.setText(blue1.getText());});
        red1.setOnAction(e->{menuButton2.setText(red1.getText());});
        yellow1.setOnAction(e->{menuButton2.setText(yellow1.getText());});
        green1.setOnAction(e->{menuButton2.setText(green1.getText());});
        white1.setOnAction(e->{menuButton2.setText(white1.getText());});
        black1.setOnAction(e->{menuButton2.setText(black1.getText());});
        purple1.setOnAction(e->{menuButton2.setText(purple1.getText());});
        orange1.setOnAction(e->{menuButton2.setText(orange1.getText());});
        pink1.setOnAction(e->{menuButton2.setText(pink1.getText());});
        gray1.setOnAction(e->{menuButton2.setText(gray1.getText());});




        InputStream iconstream5=getClass().getResourceAsStream("/images/colors/blue.png");
        ImageView imageView5 = new ImageView(new Image(iconstream5));
        imageView5.setFitHeight(40);
        imageView5.setFitWidth(40);
        blue.setGraphic(imageView5);
        blue1.setGraphic(imageView5);

        InputStream iconstream6=getClass().getResourceAsStream("/images/colors/red.png");
        ImageView imageView6 = new ImageView(new Image(iconstream6));
        imageView6.setFitHeight(40);
        imageView6.setFitWidth(40);
        red.setGraphic(imageView6);
        red1.setGraphic(imageView6);

        InputStream iconstream7=getClass().getResourceAsStream("/images/colors/yellow.png");
        ImageView imageView7 = new ImageView(new Image(iconstream7));
        imageView7.setFitHeight(40);
        imageView7.setFitWidth(40);
        yellow.setGraphic(imageView7);
        yellow1.setGraphic(imageView7);

        InputStream iconstream8=getClass().getResourceAsStream("/images/colors/green.png");
        ImageView imageView8 = new ImageView(new Image(iconstream8));
        imageView8.setFitHeight(40);
        imageView8.setFitWidth(40);
        green.setGraphic(imageView8);
        green1.setGraphic(imageView8);

        InputStream iconstream9=getClass().getResourceAsStream("/images/colors/white.png");
        ImageView imageView9 = new ImageView(new Image(iconstream9));
        imageView9.setFitHeight(40);
        imageView9.setFitWidth(40);
        white.setGraphic(imageView9);
        white1.setGraphic(imageView9);


        InputStream iconstream10=getClass().getResourceAsStream("/images/colors/black.png");
        ImageView imageView10 = new ImageView(new Image(iconstream10));
        imageView10.setFitHeight(40);
        imageView10.setFitWidth(40);
        black.setGraphic(imageView10);
        black1.setGraphic(imageView10);

        InputStream iconstream11=getClass().getResourceAsStream("/images/colors/purple.png");
        ImageView imageView11 = new ImageView(new Image(iconstream11));
        imageView11.setFitHeight(40);
        imageView11.setFitWidth(40);
        purple.setGraphic(imageView11);
        purple1.setGraphic(imageView11);

        InputStream iconstream12=getClass().getResourceAsStream("/images/colors/orange.png");
        ImageView imageView12 = new ImageView(new Image(iconstream12));
        imageView12.setFitHeight(40);
        imageView12.setFitWidth(40);
        orange.setGraphic(imageView12);
        orange1.setGraphic(imageView12);

        InputStream iconstream13=getClass().getResourceAsStream("/images/colors/pink.png");
        ImageView imageView13 = new ImageView(new Image(iconstream13));
        imageView13.setFitHeight(40);
        imageView13.setFitWidth(40);
        pink.setGraphic(imageView13);
        pink1.setGraphic(imageView13);

        InputStream iconstream14=getClass().getResourceAsStream("/images/colors/gray.png");
        ImageView imageView14 = new ImageView(new Image(iconstream14));
        imageView14.setFitHeight(40);
        imageView14.setFitWidth(40);
        gray.setGraphic(imageView14);
        gray1.setGraphic(imageView14);


        menuButton1.getItems().addAll(blue,red,yellow,green,orange,black,white,gray,pink,purple);
        menuButton2.getItems().addAll(blue1,red1,yellow1,green1,orange1,black1,white1,gray1,pink1,purple1);

        menuButton2.setPrefSize(98,25);
        menuButton2.setLayoutX(-50);
        menuButton2.setLayoutY(70);

        text6.setLayoutX(-50);
        text6.setLayoutY(10);

        text7.setLayoutX(-50);
        text7.setLayoutY(65);

        pane.getChildren().add(pane3);


        Text text8=new Text("Контур");

        Text text9=new Text("Толщина");

        Text text10=new Text("Тип");

        TextField textField3=new TextField();

        MenuButton menuButton3=new MenuButton("Solid");
        MenuItem m1=new MenuItem("Dashed");
        MenuItem m2=new MenuItem("Dotted");
        menuButton3.getItems().addAll(m1,m2);
     m1.setOnAction(e->{menuButton3.setText(m1.getText());});
        m2.setOnAction(e->{menuButton3.setText(m2.getText());});
        AnchorPane pane4=new AnchorPane(text8,text9,text10,textField3,menuButton3);
        pane4.setPrefSize(142,85);
        pane4.setLayoutX(100);
        pane4.setLayoutY(170);

        text8.setLayoutX(40);
        text8.setLayoutY(0);

        text9.setLayoutX(0);
        text9.setLayoutY(30);

        text10.setLayoutX(0);
        text10.setLayoutY(60);

        textField3.setPrefSize(85,25);
        textField3.setLayoutX(60);
        textField3.setLayoutY(10);

        menuButton3.setPrefSize(85,25);
        menuButton3.setLayoutX(60);
        menuButton3.setLayoutY(40);

        pane.getChildren().add(pane4);

        pane.setStyle("-fx-background-color: lightgray;");

        Canvas canvas=new Canvas(400,380);
        canvas.setStyle("-fx-background-color: white;");

        MenuBar menuBar=new MenuBar();
        menuBar.setPrefSize(715,26);
        menuBar.setLayoutX(0);
        menuBar.setLayoutY(0);
        MenuItem menuItem1=new MenuItem("Exit");
        MenuItem menuItem2=new MenuItem("Save");
        Menu menu1=new Menu("File");
        menu1.getItems().addAll(menuItem1,menuItem2);
        Menu menu2=new Menu("Help");
        menuBar.getMenus().addAll(menu1,menu2);
        root.getChildren().addAll(pane,canvas,menuBar);

        menuItem2.setOnAction(e-> saveAsPng(canvas.getParent(),new SnapshotParameters()));

        canvas.setOnMousePressed(e-> {
            if (line_btn.isSelected() && e.getButton() == MouseButton.SECONDARY) {

                if(!textField1.getText().isEmpty()&&!textField2.getText().isEmpty()){
                    double Width=Double.parseDouble(textField1.getText());
                    double Height=Double.parseDouble(textField2.getText());
                    Line line=new Line(e.getSceneX(),e.getSceneY(),e.getSceneX()+Width,e.getSceneY()+Height);
                    Rectangle rect1=new Rectangle(Width,Height);
                    line.setFill(Color.valueOf(menuButton1.getText()));
                    rect1.setFill(Color.WHITE);
                    rect1.setLayoutX(e.getSceneX());
                    rect1.setLayoutY(e.getSceneY());
                    rect1.getStrokeDashArray().setAll(10.0,5.0);
                    line.setStrokeWidth(Double.parseDouble(textField3.getText()));
                    line.setStroke(Color.valueOf(menuButton1.getText()));
                    if(menuButton3.getText()=="Dashed") line.setStyle("-fx-stroke-dash-array:"+textField3.getText()+" 10;");
                    else  if(menuButton3.getText()=="Solid") line.setStyle("-fx-stroke-dash-array:"+textField3.getText()+" ;");
                    else  if(menuButton3.getText()=="Dotted") line.setStyle("-fx-stroke-dash-array:"+textField3.getText()+"d 21d;");
                    root.getChildren().add(rect1);
                    root.getChildren().add(line);
                    cnt += 2;
                }

            }
            if (rect_btn.isSelected() && e.getButton() == MouseButton.SECONDARY) {
                double Width=Double.parseDouble(textField1.getText());
                double Height=Double.parseDouble(textField2.getText());

                Rectangle rectangle=new Rectangle(Width, Height);
                rectangle.setLayoutX(e.getSceneX());
                rectangle.setLayoutY(e.getSceneY());
                rectangle.setStroke(Color.valueOf(menuButton1.getText()));
                rectangle.setStrokeWidth(Double.parseDouble(textField3.getText()));
                rectangle.setFill(Color.valueOf(menuButton2.getText()));
                if(menuButton3.getText()=="Dashed") rectangle.setStyle("-fx-stroke-dash-array:"+textField3.getText()+" 10;");
                else  if(menuButton3.getText()=="Solid") rectangle.setStyle("-fx-stroke-dash-array:"+textField3.getText()+" ;");
                else  if(menuButton3.getText()=="Dotted") rectangle.setStyle("-fx-stroke-dash-array:"+textField3.getText()+" 100;");
                root.getChildren().add(rectangle);
                cnt ++;
            }
            if (circle_btn.isSelected() && e.getButton() == MouseButton.SECONDARY) {
                double Width=Double.parseDouble(textField1.getText());
                double Height=Double.parseDouble(textField2.getText());
                double r=0;
                if(Width>=Height) r=Width;
                else r=Height;
                Circle circle=new Circle(r/2);
                circle.setLayoutX(e.getSceneX()+Width/2);
                circle.setLayoutY(e.getSceneY()+Height/2);
                circle.setStroke(Color.valueOf(menuButton1.getText()));
                circle.setStrokeWidth(Double.parseDouble(textField3.getText()));
                circle.setFill(Color.valueOf(menuButton2.getText()));

                if(menuButton3.getText()=="Dashed") circle.setStyle("-fx-stroke-dash-array:"+textField3.getText()+" 10;");
                else  if(menuButton3.getText()=="Solid") circle.setStyle("-fx-stroke-dash-array:"+textField3.getText()+" ;");
                else  if(menuButton3.getText()=="Dotted") circle.setStyle("-fx-stroke-dash-array:"+textField3.getText()+" 100;");
                root.getChildren().add(circle);
                cnt ++;

            }
            if (ellipse_btn.isSelected() && e.getButton() == MouseButton.SECONDARY) {
                double Width=Double.parseDouble(textField1.getText());
                double Height=Double.parseDouble(textField2.getText());
                Ellipse ellipse=new Ellipse(Width/2,Height/2);
                ellipse.setLayoutX(e.getSceneX()+Width/2);
                ellipse.setLayoutY(e.getSceneY()+Height/2);
                ellipse.setStroke(Color.valueOf(menuButton1.getText()));
                ellipse.setFill(Color.valueOf(menuButton2.getText()));
                ellipse.setStrokeWidth(Double.parseDouble(textField3.getText()));
                if(menuButton3.getText()=="Dashed") ellipse.setStyle("-fx-stroke-dash-array:"+textField3.getText()+" 10;");
                else  if(menuButton3.getText()=="Solid") ellipse.setStyle("-fx-stroke-dash-array:"+textField3.getText()+" ;");
                else  if(menuButton3.getText()=="Dotted") ellipse.setStyle("-fx-stroke-dash-array:"+textField3.getText()+" 100;");
                root.getChildren().add(ellipse);
                cnt ++;
            }
                });



        stage.setTitle("Graphic Editor");
        stage.setScene(scene);
        stage.show();
    }
    public void saveAsPng(Node node, SnapshotParameters ssp) {
        WritableImage image = node.snapshot(ssp, null);
        FileChooser fc=new FileChooser();
        fc.getExtensionFilters().add(new FileChooser.ExtensionFilter("Image files", "*.png", "*.jpg", "*.gif"));
        File file = fc.showSaveDialog(null);
        try {
            ImageIO.write(SwingFXUtils.fromFXImage(image, null), "png", file);
        } catch (IOException e) {

        }
    }
    public static void main(String[] args) {
        launch();
    }
}

package first.java;

import javafx.application.Application;
import javafx.embed.swing.SwingFXUtils;
import javafx.scene.Node;
import javafx.scene.SnapshotParameters;
import javafx.scene.control.Button;
import javafx.scene.control.ToggleButton;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.image.WritableImage;
import javafx.scene.input.MouseButton;
import javafx.scene.layout.Pane;
import javafx.scene.Scene;
import javafx.stage.FileChooser;
import javafx.stage.Stage;

import javax.imageio.ImageIO;
import java.io.File;
import java.io.IOException;
import java.io.InputStream;

public class Task1 extends Application {
    @Override
    public void start(Stage stage)  {
        Pane root=new Pane();
        Scene scene = new Scene(root, 480, 400);
        InputStream iconstream=getClass().getResourceAsStream("/images/img1.jpg");
        stage.getIcons().add(new Image(iconstream));
        Button btn=new Button("Save");

        ToggleButton btn1=new ToggleButton();
        ToggleButton btn2=new ToggleButton();
        ToggleButton btn3=new ToggleButton();
        btn.setLayoutX(200);
        btn.setLayoutY(0);
        btn1.setLayoutX(210);
        btn1.setLayoutY(30);
        btn2.setLayoutX(210);
        btn2.setLayoutY(60);
        btn3.setLayoutX(210);
        btn3.setLayoutY(90);
        root.getChildren().add(btn);
        root.getChildren().addAll(btn1,btn2,btn3);
        scene.setOnMouseClicked(e->{
            if(btn1.isSelected()&&e.getButton() == MouseButton.SECONDARY){
                InputStream iconstream1=getClass().getResourceAsStream("/images/img2.jpg");
                Image image1=new Image(iconstream1);
                ImageView imageView = new ImageView(image1);
                imageView.setFitHeight(64);
                imageView.setFitWidth(64);
                imageView.setLayoutX(e.getSceneX());
                imageView.setLayoutY(e.getSceneY());
                root.getChildren().add(imageView);
            }
            if(btn2.isSelected()&&e.getButton() == MouseButton.SECONDARY){
                InputStream iconstream1=getClass().getResourceAsStream("/images/img3.png");
                Image image1=new Image(iconstream1);
                ImageView imageView = new ImageView(image1);
                imageView.setFitHeight(64);
                imageView.setFitWidth(64);
                imageView.setLayoutX(e.getSceneX());
                imageView.setLayoutY(e.getSceneY());
                root.getChildren().add(imageView);
            }
            if(btn3.isSelected()&&e.getButton() == MouseButton.SECONDARY){
                InputStream iconstream1=getClass().getResourceAsStream("/images/img4.png");
                Image image1=new Image(iconstream1);
                ImageView imageView = new ImageView(image1);
                imageView.setFitHeight(64);
                imageView.setFitWidth(64);
                imageView.setLayoutX(e.getSceneX());
                imageView.setLayoutY(e.getSceneY());
                root.getChildren().add(imageView);
            }
        });
        btn.setOnAction(e-> saveAsPng(scene.getRoot(),new SnapshotParameters()));
        stage.setTitle("ImageSaver");
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
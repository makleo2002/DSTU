package first.java;

import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.media.Media;
import javafx.scene.media.MediaPlayer;
import javafx.stage.Stage;

import java.io.File;
import java.net.URL;


public class Task7 extends Application {

    @Override
    public void start(Stage primaryStage) throws Exception {

        URL url = new URL("files://C:\\Users\\Максим\\IdeaProjects\\Java\\src\\main\\resources\\first\\java.Task7.fxml");
//File f;
//f.toURI().toURL()
        //FXMLLoader fxmlLoader = new FXMLLoader(getClass().getResource("/first/java/Task7.fxml"));
        FXMLLoader fxmlLoader = new FXMLLoader(url);
        Parent root = fxmlLoader.load();
        primaryStage.setTitle("MediaPlayer");
        primaryStage.setScene(new Scene(root, 1000, 500));
        primaryStage.show();
    }


    public static void main(String[] args) {
        launch(args);
    }
}
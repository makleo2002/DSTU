package com.example.gui;

import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.layout.VBox;
import javafx.scene.web.WebEngine;
import javafx.scene.web.WebHistory;
import javafx.scene.web.WebView;
import javafx.stage.Stage;

public class WebViewExample extends Application {

    public static void main(String[] args) {
        launch(args);
    }

    public void start(Stage primaryStage) {
        primaryStage.setTitle("JavaFX WebView Example");

        WebView webView = new WebView();

        WebEngine webEngine=webView.getEngine();
        webEngine.load("http://localhost:8080/OOP_Lab3_war/");

        VBox vBox = new VBox(webView);
        Scene scene = new Scene(vBox, 960, 600);

        Button back=new Button("back");
        Button forward=new Button("forward");

        vBox.getChildren().addAll(back,forward);

        WebHistory history = webEngine.getHistory();


        back.setOnAction(e->history.go(-1) );
        forward.setOnAction(e->history.go(1) );
        primaryStage.setScene(scene);
        primaryStage.show();

    }
}



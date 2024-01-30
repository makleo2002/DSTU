package first.java;

import javafx.application.Application;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.control.cell.PropertyValueFactory;

import javafx.scene.control.cell.TextFieldTableCell;
import javafx.scene.layout.BorderPane;
import javafx.scene.layout.HBox;
import javafx.stage.Stage;
import javafx.util.converter.IntegerStringConverter;

public class Task5 extends Application {

    public static class Person{
        private String name;
        private String language;
        private int year;

        Person(String language, String name, int year){
            this.year = year;
            this.name = name;
            this.language = language;
        }

        public String getName(){
            return name;
        }

        public int getYear(){
            return year;
        }

        public String getLanguage(){
            return language;
        }

        public void setName(String name){
            this.name = name;
        }
        public void setYear(int year){
            this.year = year;
        }
        public void setLanguage(String language){
            this.language = language;
        }
    }


    public static void main(String[] args) {
        launch(args);
    }

    @Override
    public void start(Stage primaryStage) {

        ObservableList<Person> people = FXCollections.observableArrayList(
                new Person("Си", "Деннис Ритчи", 1972),
                new Person("С++", "Бьерн Страуструп", 1983),
                new Person("Python", "Гвидо ван Россум", 1991),
                new Person("Java", "Джеймс Гослинг", 1995),
                new Person("JavaScript", "Брендон Айк", 1995),
                new Person("C#", "Андерс Хейлсберг", 2001),
                new Person("Scala", "Мартин Одерски", 2003)
        );

        TableView<Person> tableView = new TableView<>(people);
        tableView.setEditable(true);
        TableColumn<Person, String> languageColumn = new TableColumn<>("Язык");
        languageColumn.setCellValueFactory(new PropertyValueFactory<Person, String>("language"));
        languageColumn.setCellFactory(TextFieldTableCell.forTableColumn());
        tableView.getColumns().add(languageColumn);

        TableColumn<Person, String> nameColon = new TableColumn<>("Автор");
        nameColon.setCellValueFactory(new PropertyValueFactory<Person, String>("name"));
        nameColon.setCellFactory(TextFieldTableCell.forTableColumn());
        tableView.getColumns().add(nameColon);

        TableColumn<Person, Integer> ageColon = new TableColumn<Person, Integer>("Год");
        ageColon.setCellValueFactory(new PropertyValueFactory<Person, Integer>("year"));
        ageColon.setCellFactory(TextFieldTableCell.forTableColumn(new IntegerStringConverter()));
        tableView.getColumns().add(ageColon);


        ToggleButton languageVisible = new ToggleButton("Показать/Скрыть Язык");
        languageVisible.setOnAction(new EventHandler<ActionEvent>() {
            @Override
            public void handle(ActionEvent actionEvent) {
                languageColumn.setVisible(!languageVisible.isSelected());
            }
        });
        ToggleButton nameVisible = new ToggleButton("Показать/Скрыть Автора");
        nameVisible.setOnAction(new EventHandler<ActionEvent>() {
            @Override
            public void handle(ActionEvent actionEvent) {
                nameColon.setVisible(!nameVisible.isSelected());
            }
        });
        ToggleButton ageVisible = new ToggleButton("Показать/Скрыть Год");
        ageVisible.setOnAction(new EventHandler<ActionEvent>() {
            @Override
            public void handle(ActionEvent actionEvent) {
                ageColon.setVisible(!ageVisible.isSelected());
            }
        });
        BorderPane buttonSector = new BorderPane();
        HBox addElem = new HBox();
        HBox buttonHbox = new HBox();
        buttonHbox.getChildren().addAll(languageVisible, nameVisible, ageVisible);

        TextField languageText = new TextField("language");
        languageText.setMaxSize(100,15);
        TextField nameText = new TextField("name");
        nameText.setMaxSize(100,15);
        TextField ageText = new TextField("age");
        ageText.setMaxSize(100,15);

        Button newPerson = new Button("Добавить данные");
        addElem.getChildren().addAll(languageText, nameText, ageText, newPerson);
        buttonSector.setTop(buttonHbox);
        buttonSector.setBottom(addElem);

        newPerson.setOnAction(new EventHandler<ActionEvent>() {
            @Override
            public void handle(ActionEvent actionEvent) {
                Person person = new Person(languageText.getText(), nameText.getText(), Integer.parseInt(ageText.getText()));
                people.add(person);
            }
        });


        BorderPane Pane = new BorderPane();
        Pane.setCenter(tableView);
        Pane.setBottom(buttonSector);

        Scene scene = new Scene(Pane, 800, 600);
        primaryStage.setTitle("Таблица");
        primaryStage.setScene(scene);
        primaryStage.show();
    }
}

package first.java;
import javafx.beans.binding.Bindings;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.Slider;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.input.KeyCode;
import javafx.scene.input.KeyEvent;
import javafx.scene.layout.HBox;
import javafx.scene.layout.VBox;
import javafx.scene.media.Media;
import javafx.scene.media.MediaPlayer;
import javafx.scene.media.MediaView;
import javafx.stage.Stage;
import javafx.util.Duration;

import java.io.File;
import java.net.URL;
import java.util.ResourceBundle;


public class Controller implements Initializable {
    @FXML
    private VBox vboxParent;

    @FXML
    private MediaView mvVideo;
    private MediaPlayer mpVideo;
    private Media mediaVideo;

    @FXML
    private HBox hboxControls;

    @FXML
    private HBox hboxVolume;

    @FXML
    private Button buttonPPR;

    @FXML
    private Label labelCurrentTime;
    @FXML
    private Label labelTotalTime;
    @FXML
    private Label labelFullScreen;
    @FXML
    private Label labelSpeed;
    @FXML
    private Label labelVolume;

    @FXML
    private Slider sliderVolume;
    @FXML
    private Slider sliderTime;


    private boolean atEndOfVideo=false;
    private boolean isPlaying=true;
    private boolean isMuted=true;

    private ImageView ivPlay;
    private ImageView ivPause;
    private ImageView ivRestart;
    private ImageView ivVolume;
    private ImageView ivFullScreen;
    private ImageView ivMute;
    private ImageView ivExit;


    @Override
    public void initialize(URL url, ResourceBundle resourceBundle) {
        final int IV_SIZE = 25;
    mediaVideo=new Media(new File("src/main/resources/media/final.mp4").toURI().toString());
    mpVideo=new MediaPlayer(mediaVideo);
    mvVideo.setMediaPlayer(mpVideo);

    Image imagePlay=new Image(new File("src/main/resources/media/play-btn.png").toURI().toString());
    ivPlay=new ImageView(imagePlay);
    ivPlay.setFitHeight(IV_SIZE);
    ivPlay.setFitWidth(IV_SIZE);

    Image imageStop=new Image(new File("src/main/resources/media/stop-btn.png").toURI().toString());
    ivPause=new ImageView(imageStop);
    ivPause.setFitHeight(IV_SIZE);
    ivPause.setFitWidth(IV_SIZE);

    Image imageRestart=new Image(new File("src/main/resources/media/restart-btn.png").toURI().toString());
    ivRestart=new ImageView(imageRestart);
    ivRestart.setFitHeight(IV_SIZE);
    ivRestart.setFitWidth(IV_SIZE);

    Image imageVol=new Image(new File("src/main/resources/media/volume.png").toURI().toString());
    ivVolume=new ImageView(imageVol);
    ivVolume.setFitHeight(IV_SIZE);
    ivVolume.setFitWidth(IV_SIZE);

    Image imageFull=new Image(new File("src/main/resources/media/fullscreen.png").toURI().toString());
    ivFullScreen=new ImageView(imageFull);
    ivFullScreen.setFitHeight(IV_SIZE);
    ivFullScreen.setFitWidth(IV_SIZE);

    Image imageMute=new Image(new File("src/main/resources/media/mute.png").toURI().toString());
    ivMute=new ImageView(imageMute);
    ivMute.setFitHeight(IV_SIZE);
    ivMute.setFitWidth(IV_SIZE);

    Image imageExit=new Image(new File("src/main/resources/media/exitscreen.png").toURI().toString());
    ivExit=new ImageView(imageExit);
    ivExit.setFitHeight(IV_SIZE);
    ivExit.setFitWidth(IV_SIZE);

    buttonPPR.setGraphic(ivPause);
    labelVolume.setGraphic(ivMute);
    labelSpeed.setText("1X");
    labelFullScreen.setGraphic(ivFullScreen);
    hboxVolume.getChildren().remove(sliderVolume);

    buttonPPR.setOnAction(actionEvent -> {
        Button buttonPlay=(Button) actionEvent.getSource();
        if(atEndOfVideo){
            sliderTime.setValue(0);
            atEndOfVideo=false;
            isPlaying=false;
        }
        if(isPlaying){
            buttonPlay.setGraphic(ivPlay);
            mpVideo.pause();
            isPlaying=false;
        }
        else{
            buttonPlay.setGraphic(ivPause);
            mpVideo.play();
            isPlaying=true;
        }
    });


    mpVideo.volumeProperty().bindBidirectional(sliderVolume.valueProperty());



    sliderVolume.valueProperty().addListener(observable -> {
        mpVideo.setVolume(sliderVolume.getValue());
        if(mpVideo.getVolume()!=0.0){
            labelVolume.setGraphic(ivVolume);
            isMuted=false;
        }
        else{
            labelVolume.setGraphic(ivMute);
            isMuted=true;
        }
    });

    mpVideo.play();

    labelSpeed.setOnMouseClicked(mouseEvent -> {
        if(labelSpeed.getText().equals("1X")){
            labelSpeed.setText("2X");
            mpVideo.setRate(2.0);
        }
        else{
            labelSpeed.setText("1X");
            mpVideo.setRate(1.0);
        }
    });
    labelVolume.setOnMouseClicked(mouseEvent -> {
        if(isMuted) {
            labelVolume.setGraphic(ivVolume);
            sliderVolume.setValue(0.2);
            isMuted=false;
        }
        else{
            labelVolume.setGraphic(ivMute);
            sliderVolume.setValue(0);
            isMuted=true;
        }
    });

    labelVolume.setOnMouseEntered(mouseEvent -> {
        if(hboxVolume.lookup("#sliderVolume")==null){
            hboxVolume.getChildren().add(sliderVolume);
            sliderVolume.setValue(mpVideo.getVolume());
        }
    });

    hboxVolume.setOnMouseExited(mouseEvent -> hboxVolume.getChildren().remove(sliderVolume));

    vboxParent.sceneProperty().addListener((observableValue, oldScene, newScene) -> {
        if(oldScene==null && newScene!=null){
            mvVideo.fitHeightProperty().bind(newScene.heightProperty().subtract(hboxControls.heightProperty().add(20)));
        }
    });

    labelFullScreen.setOnMouseClicked(mouseEvent -> {
        Label label=(Label) mouseEvent.getSource();
        Stage stage=(Stage) label.getScene().getWindow();
        if(stage.isFullScreen()){
            stage.setFullScreen(false);
            labelFullScreen.setGraphic(ivFullScreen);
        }
        else{
            stage.setFullScreen(true);
            labelFullScreen.setGraphic(ivExit);
        }
        stage.addEventHandler(KeyEvent.KEY_PRESSED, keyEvent -> {
            if(keyEvent.getCode()== KeyCode.ESCAPE){
                labelFullScreen.setGraphic(ivFullScreen);
            }
        });
    });

    mpVideo.totalDurationProperty().addListener((observableValue, oldDuration, newDuration) -> {
    sliderTime.setMax(newDuration.toSeconds());
    labelTotalTime.setText(getTime(newDuration));
    });


    sliderTime.valueChangingProperty().addListener((observableValue, wasChanging, isChanging) -> {
        if(!isChanging){
            mpVideo.seek(Duration.seconds(sliderTime.getValue()));
        }
    });

    sliderTime.valueProperty().addListener((observableValue, oldValue, newValue) -> {
        bindCurrentTimeLabel();
        double currentTime=mpVideo.getCurrentTime().toSeconds();
        if(Math.abs(currentTime-newValue.doubleValue())>0.5){
            mpVideo.seek(Duration.seconds(newValue.doubleValue()));
        }
        labelMatchEndVideo(labelCurrentTime.getText(),labelTotalTime.getText());
    });

    mpVideo.currentTimeProperty().addListener((observableValue, oldTime, newTime) -> {
        if(!sliderTime.isValueChanging()){
            sliderTime.setValue(newTime.toSeconds());
        }
        labelMatchEndVideo(labelCurrentTime.getText(),labelTotalTime.getText());
    });

    mpVideo.setOnEndOfMedia(() -> {
        buttonPPR.setGraphic(ivRestart);
        atEndOfVideo=true;
        if(!labelCurrentTime.textProperty().equals(labelTotalTime.textProperty())){
            labelCurrentTime.textProperty().unbind();
            labelCurrentTime.setText(getTime(mpVideo.getTotalDuration())+" / ");
        }
    });
    }

    public void bindCurrentTimeLabel(){
        labelCurrentTime.textProperty().bind(Bindings.createStringBinding(() -> getTime(mpVideo.getCurrentTime())+" / ",mpVideo.currentTimeProperty()));
    }

    public String getTime(Duration time){

        int hours=(int) time.toHours();
        int minutes=(int) time.toMinutes();
        int seconds=(int) time.toSeconds();

        if(seconds>59) seconds=seconds%60;
        if(minutes>59) minutes=minutes%60;
        if(hours>59) hours=hours%60;

        if(hours>0) return String.format("%d:%02d:%02d",
                hours,
                minutes,
                seconds);
        else return String.format("%02d:%02d",
                minutes,seconds);
    }

    public void labelMatchEndVideo(String labelTime, String labelTotalTime){
        for(int i=0;i<labelTotalTime.length();i++){
            if(labelTime.charAt(i)!=labelTotalTime.charAt(i)){
                atEndOfVideo=false;
                if(isPlaying) buttonPPR.setGraphic(ivPause);
                else buttonPPR.setGraphic(ivPlay);
                break;
            }
           else{
               atEndOfVideo=true;
               buttonPPR.setGraphic(ivRestart);
            }
        }
    }

}
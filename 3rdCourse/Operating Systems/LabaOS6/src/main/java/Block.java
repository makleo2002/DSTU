import java.io.FileWriter;
import java.io.IOException;

//спец область,содержит информацию о каталоге
public class Block {
    String absPath = "";//абсолютный путь
    String nameOfFile = "";
    String[] Blocks;

    public Block(String str, String name){
        Blocks = new String[12];
        absPath = str;
        nameOfFile = name;

        try {
            FileWriter fw = new FileWriter(absPath);//записываем в файл информацию о блоках
            for (int i = 0; i < 12; i++){
                fw.write(i + " : {  }\n");
                Blocks[i] = "";
            }
            fw.close();
        } catch (IOException e){
            e.printStackTrace();
        }
    }

    public String getAbsPath() {
        return absPath;
    }
    public String getElem(int i){
        return Blocks[i];
    }

    public void setBlocksArr(int i, String str) {
        Blocks[i] = str;
    }

    //вывести информацию о блоках
    public void printInfo(){
        System.out.println("Имя файла: "+nameOfFile);
        for (int i = 0; i < 12; i++){
            System.out.println("Блок " + i + ": " + Blocks[i]);
        }
    }

    //сохранить информацию о блоках в файле
    public void saveInfoBlock(){
        try {
            FileWriter fw = new FileWriter(absPath);
            for (int i = 0; i < 12; i++){
                fw.write(i + " : { " + Blocks[i] + " }\n");
            }
            fw.close();
        } catch (IOException e){
            e.printStackTrace();
        }
    }
}

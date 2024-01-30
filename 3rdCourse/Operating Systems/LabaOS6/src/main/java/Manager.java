import java.io.File;
import java.util.ArrayList;
import java.util.Scanner;

public class Manager {

    ArrayList<Catalog> catalogArr = new ArrayList<>();//массив каталогов

    ArrayList<Block> BlockArr = new ArrayList<>();
    String currentCatalog;//текущий каталог
    int currentNumber;//номер текущего каталога

    public Manager(){
        Block currentFile = new Block("C:\\Users\\Максим\\IdeaProjects\\LabaOS6\\current.txt", "current.txt");//
        BlockArr.add(currentFile);//создаем блок
        Catalog catalog = new Catalog("current.txt", BlockArr.size() - 1);//создаем каталог
        catalogArr.add(catalog);
        currentCatalog = "C:\\Users\\Максим\\IdeaProjects\\LabaOS6\\";
        currentNumber = catalogArr.size()-1;//записываем номер последнего каталога
    }

    public void createNewFile(String name){
        //создаем новый блок и определяем каталог
        Block currentFile = new Block(currentCatalog + "\\" + name + ".txt", name + ".txt");
        BlockArr.add(currentFile);
        Catalog catalog = new Catalog(name+".txt", BlockArr.size() - 1);
        catalogArr.add(catalog);
        currentNumber = catalogArr.size()-1;
    }

    //открываем файл(получаем текущий блок из текущего каталога и выводим информацию)
    public void openFile(){
        BlockArr.get(catalogArr.get(currentNumber).getActualBlock()).printInfo();
    }

    //задаем текущий блок
    public void setPosition(int numBlock) {
        if (numBlock < 0 || numBlock > 14) {
            System.out.println("Error: Block not found");
            return;
        }
        //ставим текущую позицию в файле
        catalogArr.get(currentNumber).setCurrentInfoBlock(numBlock);
    }

    //прочитать блок
    public void readBlock(){

        String tmp = "";
        if (catalogArr.get(currentNumber).getCurrentInfoBlock() < 12){
           Block actualBlock=BlockArr.get( catalogArr.get(currentNumber).getActualBlock() );//получаем текущий блок
           int curInfoBlock=catalogArr.get(currentNumber).getCurrentInfoBlock();//номер блока в каталоге
            tmp = actualBlock.getElem(curInfoBlock);//получаем информацию о текущем блоке из каталога
        }
        System.out.println(tmp);
    }

    //записать в блок
    public void writeInBlock(String text) {
        //если количество блоков в каталоге соответствует значению по умолчанию
        if (catalogArr.get(currentNumber).getCurrentInfoBlock() < 12){
            int blockNum=catalogArr.get(currentNumber).getActualBlock();//получаем номер текущего блока
            int curInfoBlock=catalogArr.get(currentNumber).getCurrentInfoBlock();//номер блока в каталоге
            BlockArr.get(blockNum).setBlocksArr(curInfoBlock, text);//записываем в блок строку
        }

    }

    //Закрываем файл
    public void closeFile(){
        catalogArr.get(currentNumber).setCurrentInfoBlock(0);
    }

    //удалить файл
    public void deleteFile(){
//выводим файлы из текущего каталога
        File f = new File(currentCatalog);
        File[] arr = f.listFiles();
        for (int i = 0; i < arr.length; i++){
            System.out.println(i + ") " + arr[i].getAbsolutePath());
        }
        //удаляем файл с текущим индексом
        Scanner sc = new Scanner(System.in);
        int index = sc.nextInt();
        //если файл текущий,не можем удалить
        if (arr[index].equals(new File(BlockArr.get(catalogArr.get(currentNumber).getActualBlock()).getAbsPath()))){
            System.out.println("Удаление текущего файла невозможно");
        }
        arr[index].delete();

    }

    //поиск файла в каталоге
    public void searchFileInCatalog(){

        File f = new File(currentCatalog);
        if (!f.isDirectory()){
            System.out.println("Каталог не обнаружен" );
            return;
        }

        File[] arr = f.listFiles();//просматриваем файлы каталогна
        for (int i = 0; i < arr.length; i++){
            System.out.println(i + ") " + arr[i].getAbsolutePath());
        }

        Scanner sc = new Scanner(System.in);
        System.out.println("Ввод индекса: ");
        int index = sc.nextInt();
        //вводим индекс файла.
        if (arr[index].isFile()){//если это файл
            closeFile();//закрываем файл
            Block currentFile = new Block(arr[index].getAbsolutePath(), arr[index].getName());//создаем блок на основе файла
            BlockArr.add(currentFile);
            catalogArr.get(currentNumber).setActualBlock(BlockArr.size()-1);//устанавливаем текущий блок

        }

    }

    //создать каталог с указанным именем
    public String createCatalog(String name){

        File f = new File(currentCatalog + "\\" + name);
        f.mkdir();
        return "Catalog create " + currentCatalog + "\\" + name;
    }

    //удалить каталог в текущей директории,если пуст
    public void deleteEmptyCatalog(){
        File f = new File(currentCatalog);
        File[] arr = f.listFiles();
        for (File t: arr){
            if (t.isDirectory()){
                if (t.listFiles().length == 0){ // если файлов - нет удаляем
                    t.delete();
                    return;
                }
            }
        }
    }

    //меняем текущий каталог
    public void changeCatalog(String cat){
        File f = new File(cat);
        if (f.isDirectory()){
            currentCatalog = f.getAbsolutePath();
        }
    }


    //получаем информацию о каталоге
    public void getInfo(){

        File f = new File(currentCatalog);
        System.out.println("Каталог: " + currentCatalog);
        File[] arr = f.listFiles();
        System.out.println("Список файлов: ");
        for (int i = 0; i < arr.length; i++){
            System.out.println(i + ") " + arr[i].getAbsolutePath());
        }
    }

    //сохраняем информацию о текущем блоке

    public void saveInfo(){

        System.out.println("Сохранение...");
        BlockArr.get(catalogArr.get(currentNumber).getActualBlock()).saveInfoBlock();
    }

}

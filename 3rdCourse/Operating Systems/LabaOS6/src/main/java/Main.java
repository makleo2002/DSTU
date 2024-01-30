import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);//ввод
        Manager fs = new Manager();

        while (true) {
            System.out.print("\nМеню:" +
                    "\n1) Создать новый файл" +
                    "\n2) Вывести текущий файл" +
                    "\n3) Изменить текущую позицию в файле" +
                    "\n4) Считать блок данных из файла" +
                    "\n5) Записать в блок данных информацию" +
                    "\n6) Закрыть файл" +
                    "\n7) Удалить существующий файл" +
                    "\n8) Поиск файлов и каталогов" +
                    "\n9) Создать каталог" +
                    "\n10) Удалить пустой каталог" +
                    "\n11) Изменить текущий каталог" +
                    "\n12) Получить информацию о текущем каталоге" +
                    "\n13) Сохранить данные в файл" +
                    "\n14) Выход " +
                    "\n\nВаш ответ: ");

            int choice = sc.nextInt();
            switch (choice) {
                case 1 -> {
                    System.out.println("Введите имя для нового файла: ");
                    String line = sc.next();
                    fs.createNewFile(line);
                }
                case 2 -> {
                    fs.openFile();
                }
                case 3 -> {
                    System.out.println("Введите номер блока: ");
                    int num = sc.nextInt();
                    fs.setPosition(num);
                }
                case 4 -> {
                    fs.readBlock();
                }
                case 5 -> {
                    System.out.println("Введите свои данные");
                    String text = sc.next();
                    fs.writeInBlock(text);
                }
                case 6 -> {
                    fs.closeFile();
                }
                case 7 -> {
                    fs.deleteFile();
                }
                case 8 -> {
                    fs.searchFileInCatalog();
                }
                case 9 -> {
                    System.out.println("Введите новое имя каталога: ");
                    String name = sc.next();
                    fs.createCatalog(name);
                }
                case 10 -> {
                    fs.deleteEmptyCatalog();
                }
                case 11 -> {
                    System.out.println("Введите путь к новому каталогу: ");
                    String absPath = sc.next();
                    System.out.println(absPath.toString());
                    fs.changeCatalog(absPath);
                }
                case 12 -> {
                    fs.getInfo();
                }
                case 13 -> {
                    fs.saveInfo();
                }
                case 14 -> {
                    return;
                }
            }
        }

    }
}

import java.io.BufferedReader;
import java.io.File;
import java.io.IOException;
import java.io.InputStreamReader;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

public class Main {
    private static String readBufferedStream(BufferedReader rdr) throws IOException {
        String result = "";
        char[] buf = new char[256];
        int res = -1;
        while ((res = rdr.read(buf)) != -1) {
            result += new String(buf, 0, res);
        }
        return result;
    }
    private static Boolean checkX(char[] mas){
        for(int i=0;i<mas.length;i++){
            if(mas[i]=='x') return true;
        }
        return false;
    }
    public static void Task4(String myPath) throws IOException, InterruptedException {
        Path path=Paths.get(myPath);
        String cmd ="ls -l "+myPath;
        BufferedReader is = null;
        String result;
        try {
            Process  pr = Runtime.getRuntime().exec(cmd);
            is = new BufferedReader(new InputStreamReader(pr.getInputStream()));
            result= readBufferedStream(is);
            System.out.println(result);
        } finally {
            if (is != null) {
                is.close();
            }
        }
        var info=result.toCharArray();
        if(Files.exists(path)&&checkX(info)) {
            ProcessBuilder builder=new ProcessBuilder(myPath);
            Process process=builder.start();
            while(process.isAlive()){
                Thread.sleep(3000);
            }
            File file=new File(myPath);
            file.delete();
        }
        else{
            System.out.println("File is not found or isnt executable");
            Thread.sleep(5000);
            Task4(myPath);
        }

    }
    public static void Task5(String dir1,String dir2) throws IOException, InterruptedException {

        File file =new File(dir1);
        File[] mas=file.listFiles();
        for(int i=0;i<mas.length;i++){
            String cmd = "cp -r "+mas[i]+" "+dir2+"/.";
            Process pr = Runtime.getRuntime().exec(cmd);
            pr.waitFor();
        }


    }
    public static void main(String[] args) throws IOException, InterruptedException {
        Task5("/home/admin/dir1","/home/admin/dir2");
        //Task4("/home/admin/files/gnome-calendar");
        //Task4("/home/admin/files/zenity-calendar.png");
    }
}
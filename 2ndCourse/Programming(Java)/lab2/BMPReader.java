package lab2;

import java.io.BufferedInputStream;
import java.io.FileInputStream;
import java.io.IOException;
import java.nio.charset.StandardCharsets;

class BMPReader {

	static String file = "C:\\material\\circle-rgb-color-mix.bmp";

	public static String byteToString(byte[] arr){
		String str = new String(arr,  StandardCharsets.UTF_8);
		return str;
	}

	public static int byteToint(byte b[]) {
		int t1 = (b[3] & 0xff) << 24;
		int t2 = (b[2] & 0xff) << 16;
		int t3 = (b[1] & 0xff) << 8;
		int t4 = b[0] & 0xff;
		return t1 + t2 + t3 + t4;
	}

	public static int bitToX(byte b[]){
		int t4 = b[0] & 0xff;
		return t4;
	}

	public static int byteToShort(byte b[]) {
		int t3 = (b[1] & 0xff) << 8;
		int t4 = b[0] & 0xff;
		return t3 + t4;
	}

	public static int check = 0;

	public static void main(String[] args) throws IOException {
//		String file = "C:\\material\\circle-rgb-color-mix.bmp";
		String nextFile = "C:\\material\\Без названия(cod).bmp";

		FileInputStream fis = new FileInputStream(file);
		BufferedInputStream bis = new BufferedInputStream(fis);

		/////Header
		BitMapFileHeader bmfh = new BitMapFileHeader();
		bmfh.readBMPHeader(bis);
		BitMapInfoHeader bmih = new BitMapInfoHeader();
		bmih.readBMP(bis);

		WriteBMP wbmp = new WriteBMP();
		nextFile = "C:\\material\\Без названия(red).bmp";
		check = 1;
		wbmp.writeToBMP(nextFile);
		check = 2;
		nextFile = "C:\\material\\Без названия(green).bmp";
		wbmp.writeToBMP(nextFile);
		check = 3;
		nextFile = "C:\\material\\Без названия(blue).bmp";
		wbmp.writeToBMP(nextFile);
		check = 4;
		nextFile = "C:\\material\\Без названия(allColor).bmp";
		wbmp.writeToBMP(nextFile);

	//	Color map
	//  ColorMap cm = new ColorMap();
	//	cm.readColorMap();
		MaskSection ms = new MaskSection();
		ms.sectionColor();
	}
}

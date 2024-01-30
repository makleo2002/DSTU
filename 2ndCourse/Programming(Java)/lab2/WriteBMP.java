package lab2;

import java.awt.*;
import java.io.*;

import static lab2.BMPReader.byteToint;
import static lab2.BMPReader.check;

class WriteBMP {

	public static String fileOrig = BMPReader.file;
	private static int height;
	private static int width;

	private static byte[]temp1 = new byte[18];
	private static byte[]temp2 = new byte[28];

	public static void writeToBMP(String file, int[][] mapMask) throws IOException {
		FileInputStream fis = new FileInputStream(fileOrig);
		BufferedInputStream bis = new BufferedInputStream(fis);
		byte[] wb = new byte[4]; // Чтение массива байтов
		byte[] hb = new byte[4]; // Считать байтовый массив высоты
			bis.read(temp1); // bis.skip (18); // пропустить первые 18 байт
			bis.read(wb); // ширина считывания
			bis.read(hb); // Считать высоту
			bis.read(temp2);
		width = BMPReader.byteToint(wb);
		height = BMPReader.byteToint(hb);
		int[][] map;
		if(check == 4){
			map = mapMask;
		}else {
			map = ColorMap.readColorMap();
		}
		FileOutputStream fos = new FileOutputStream(file);
		BufferedOutputStream bos = new BufferedOutputStream(fos);
		bos.write(temp1);
		bos.write(wb);
		bos.write(hb);
		width = byteToint(wb);
		height = byteToint(hb);
		bos.write(temp2);
		for (int i = 0; i < height; i++) {
			for (int j = 0; j < width; j++) {
				Color c = new Color(map[i][j]);
				int red = 0;
				int green = 0;
				int blue = 0;
				switch (check) {
					case 1:
						red = c.getRed();
						green = Color.BLACK.getRGB();
						blue = Color.BLACK.getRGB();
						System.out.println("cool");
						break;
					case 2:
						red = Color.BLACK.getRGB();
						green = c.getGreen();
						blue = Color.BLACK.getRGB();
						break;
					case 3:
						red = Color.BLACK.getRGB();
						green = Color.BLACK.getRGB();
						blue = c.getBlue();
						break;
					case 4:
						red = c.getRed();
						green = c.getGreen();
						blue = c.getBlue();
				}
				bos.write(blue);
				bos.write(green);
				bos.write(red);
			}
		}
		bos.flush();
		fos.close();
	}


	public static void writeToBMP(String file) throws IOException {
		FileInputStream fis = new FileInputStream(fileOrig);
		BufferedInputStream bis = new BufferedInputStream(fis);
		byte[] wb = new byte[4]; // Чтение массива байтов
		byte[] hb = new byte[4]; // Считать байтовый массив высоты
		bis.read(temp1); // bis.skip (18); // пропустить первые 18 байт
		bis.read(wb); // ширина считывания
		bis.read(hb); // Считать высоту
		bis.read(temp2);
		width = BMPReader.byteToint(wb);
		height = BMPReader.byteToint(hb);
		int[][] map;
		map = ColorMap.readColorMap();
		FileOutputStream fos = new FileOutputStream(file);
		BufferedOutputStream bos = new BufferedOutputStream(fos);
		bos.write(temp1);
		bos.write(wb);
		bos.write(hb);
		bos.write(temp2);
		for (int i = 0; i < height; i++) {
			for (int j = 0; j < width; j++) {
				Color c = new Color(map[i][j]);
				int red = 0;
				int green = 0;
				int blue = 0;
				switch (check) {
					case 1:
						red = c.getRed();
						green = Color.BLACK.getRGB();
						blue = Color.BLACK.getRGB();
						break;
					case 2:
						red = Color.BLACK.getRGB();
						green = c.getGreen();
						blue = Color.BLACK.getRGB();
						break;
					case 3:
						red = Color.BLACK.getRGB();
						green = Color.BLACK.getRGB();
						blue = c.getBlue();
						break;
					case 4:
						red = c.getRed();
						green = c.getGreen();
						blue = c.getBlue();
				}
				bos.write(blue);
				bos.write(green);
				bos.write(red);
			}
		}
		bos.flush();
		fos.close();
	}
}

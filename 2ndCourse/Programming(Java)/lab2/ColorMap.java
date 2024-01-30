package lab2;

import java.awt.*;
import java.io.BufferedInputStream;
import java.io.FileInputStream;
import java.io.IOException;

import static lab2.BMPReader.*;

class ColorMap {
	static int[][] map;
	static int width;
	static int height;

	public static int[][] readColorMap() throws IOException {

		FileInputStream fis = new FileInputStream(file);
		BufferedInputStream bis = new BufferedInputStream(fis);
		byte[] wb = new byte[4]; // Чтение массива байтов
		byte[] hb = new byte[4]; // Считать байтовый массив высоты

		bis.skip(18);
		bis.read(wb);
		bis.read(hb);
		width = BMPReader.byteToint(wb);
		height = BMPReader.byteToint(hb);
		map = new int[height][width];
		bis.skip(28);
		for (int i = 0; i < height; i++) {
			for (int j = 0; j < width; j++) {
				int blue = bis.read();
				int green = bis.read();
				int red = bis.read();
				Color c = new Color(red, green, blue);
				map[i][j] = c.getRGB();
			}
		}
		return map;
		//printMas();
	}

	public void printMas(){
		System.out.println();
		for(int i = 0; i < map.length; i++){
			for(int j = 0; j < map[i].length; j++){
				System.out.print(map[i][j] + " ");
			}
			System.out.println();
		}
	}
}

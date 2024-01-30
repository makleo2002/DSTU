package lab2;

import java.awt.*;
import java.io.IOException;

import static lab2.BMPReader.check;

class MaskSection {

	private String fileOrig = "C:\\material\\";
	public void sectionColor() throws IOException {
		int[][] map;
		for(int k = 0; k < 8; k++) {
			int mask = 2;
			mask = (int) Math.pow(mask, k);
			map = ColorMap.readColorMap();
			for(int i = 0; i < ColorMap.height; i++){
				for(int j = 0; j < ColorMap.width; j++){
					Color c = new Color(map[i][j]);
					int red = c.getRed();
					int green = c.getGreen();
					int blue = c.getBlue();
					int average =(int)((0.3 * red) + (0.6 * green) + (0.1 * blue));
					red = average & mask;
					green = average & mask;
					blue = average & mask;
					Color cOut = new Color(red, green, blue);
					map[i][j] = cOut.getRGB();
				}
			}
			check = 4;
			String file = fileOrig + k + ".bmp";
			WriteBMP.writeToBMP(file, map);
		}
	}
}

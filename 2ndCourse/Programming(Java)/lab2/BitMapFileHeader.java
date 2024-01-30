package lab2;

import java.io.BufferedInputStream;
import java.io.FileNotFoundException;

class BitMapFileHeader {
	String bfType;
	long bfSize;
	int bfReserved1;
	int bfReserves2;
	long bfOffBits;

	BitMapFileHeader(){}

	public void readBMPHeader(BufferedInputStream bis) throws FileNotFoundException {
		try {
			byte[] bfTypeArr = new byte[2];
			byte[] bfSizeArr = new byte[4];
			byte[] bfReserved1Arr = new byte[2];
			byte[] bfReserved2Arr = new byte[2];
			byte[] bfOffBitsArr = new byte[4];
			bis.read(bfTypeArr);
			bis.read(bfSizeArr);
			bis.read(bfReserved1Arr);
			bis.read(bfReserved2Arr);
			bis.read(bfOffBitsArr);

			bfType = BMPReader.byteToString(bfTypeArr);
			bfSize = BMPReader.byteToint(bfSizeArr);
			bfOffBits = BMPReader.byteToint(bfOffBitsArr);

		} catch (Exception ex){
			ex.printStackTrace();
		}
		printHeader();
	}

	public void printHeader(){
		System.out.println("\n----FileHeader----" +
				"\nbfType = " + bfType +
				"\nbfSize = " + bfSize +
				"\nbfOffBits = " + bfOffBits);
	}

}

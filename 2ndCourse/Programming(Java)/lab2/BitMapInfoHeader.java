package lab2;

import java.io.BufferedInputStream;
import java.io.IOException;

class BitMapInfoHeader {
	int width;
	int height;
	int planes;
	int bitCount;
	int compression;
	int sizeImage;
	int clrUsed;
	int clrImportant;

	BitMapInfoHeader(){}

	public void readBMP(BufferedInputStream bis) throws IOException {
		byte[] widthArr = new byte[4];
		byte[] heightArr = new byte[4];
		byte[] planesArr = new byte[2];
		byte[] bitCountArr = new byte[2];
		byte[] compressionArr = new byte[4];
		byte[] sizeImageArr = new byte[4];
		//34
		byte[] xPelsPerMeterArr = new byte[6];
		byte[] yPelsPerMeterArr = new byte[6];
		byte[] clrUsedArr = new byte[2];
		byte[] clrImportantArr = new byte[2]; //16
		bis.skip(4); 
		bis.read(widthArr);
		bis.read(heightArr);
		bis.read(planesArr);
		bis.read(bitCountArr);
		bis.read(compressionArr);
		//bis.skip(6);
		bis.read(sizeImageArr);
		bis.read(xPelsPerMeterArr);
		bis.read(yPelsPerMeterArr);
		bis.read(clrUsedArr);
		bis.read(clrImportantArr);
		width = BMPReader.byteToint(widthArr);
		height = BMPReader.byteToint(heightArr);
		planes = BMPReader.byteToShort(planesArr);
		bitCount = BMPReader.byteToShort(bitCountArr);
		compression = BMPReader.byteToint(compressionArr);
		sizeImage = BMPReader.byteToint(sizeImageArr);
		clrUsed = BMPReader.byteToShort(clrUsedArr);
		clrImportant = BMPReader.byteToShort(clrImportantArr);
		printInfoHeader();
	}

	public void printInfoHeader(){
		System.out.println("\n----InfoHeader----" +
				"\nwidth = " + width +
				"\nheight = " + height +
				"\nplanes = " + planes +
				"\nbitCount = " + bitCount +
				"\ncompression = " + compression +
				"\nsizeImage = " + sizeImage +
				"\nclrUsedArr = " + clrUsed +
				"\nclrImportantArr = " + clrImportant
		);
	}
}

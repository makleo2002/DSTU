import lombok.Getter;
import lombok.Setter;

public class Catalog {

	@Getter @Setter
	private	String fileName;
	@Getter @Setter
	private int actualBlock;//текущий файл(номер файл)
	@Getter @Setter
	private int currentInfoBlock;//информация о текущем блоке в файле

	Catalog(String fileName, int actualBlock){
		this.fileName = fileName;
		this.actualBlock = actualBlock;
		currentInfoBlock = 0;
	}
}

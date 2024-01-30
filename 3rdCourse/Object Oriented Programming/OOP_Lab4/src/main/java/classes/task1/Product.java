package classes.task1;


public class Product
{
    private int id;
    private String name;
    private int id_manufacturer;
    private int id_category;
    private int price;
    private int id_store;



    public Product(int id, String name, int id_manufacturer, int id_category, int price, int id_store )
    {
        this.id = id;
        this.id_category = id_category;
        this.id_manufacturer = id_manufacturer;
        this.id_store = id_store;
        this.price = price;
        this.name = name;
    }

    public int getId() { return id; }

    public void setId(int m_id) { this.id = m_id; }

    public int getIdCategory() { return id_category; }

    public void setIdCategory(int id_category) { this.id_category = id_category; }

    public String getName() { return name; }

    public void setName(String m_name) { this.name = m_name; }

    public int getId_Manufacturer() { return id_manufacturer; }

    public void setId_Manufacturer(int id_manufacturer) { this.id_manufacturer = id_manufacturer; }

    public int getPrice() { return price; }

    public void setPrice(int price) { this.price=price; }

    public int getId_store() { return id_store; }

    public void setId_store(int id_store) { this.id_store=id_store; }


    public String categoryIdToString()
    {
        String str = switch (id_category)
                {
                    case 1 -> "Household Appliances";
                    case 2 -> "Smart Phones & Camera & Photo";
                    case 3 -> "TV & Consoles & Audio";
                    case 4 -> "Computers & Accessories";
                    case 5 -> "Office & Furniture";
                    default -> "";
                };

        return str;
    }

    public String manufacturerIdToString()
    {
        String str = switch (id_manufacturer)
                {
                    case 1 -> "Scarlett";
                    case 2 -> "Samsung";
                    case 3 -> "Sony";
                    case 4 -> "Acer";
                    case 5 -> "Epson";
                    default -> "";
                };

        return str;
    }

    public String StoreToString()
    {
        String str = switch (id_store)
                {
                    case 1 -> "DNS";
                    case 2 -> "Eldorado";
                    case 3 -> "Mvideo";
                    case 4 -> "Citilink";
                    case 5 -> "Ozon";
                    default -> "";
                };

        return str;
    }



}

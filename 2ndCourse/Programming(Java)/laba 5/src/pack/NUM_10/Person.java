package pack.NUM_10;

import pack.NUM_9.HashTable;

public class Person{
    private String firstName;
    private String lastname;
    private int age;

    public Person(String firstName, String lastname) {
        this.firstName = firstName;
        this.lastname = lastname;
    }

    public Person(String firstName, String lastname, int age) {
        this.firstName = firstName;
        this.lastname = lastname;
        this.age = age;
    }

    public String getFirstName() {
        return firstName;
    }

    public String getLastname() {
        return lastname;
    }

    public int getAge() {
        return age;
    }

    public void view() {
        System.out.println("First name: " + this.firstName);
        System.out.println("Last name: " + this.lastname);
        System.out.println("Age: " + this.age);
    }
}

class NUM_10 {
    public static void main(String[] args) {
        HashTable<String, Person> hashTable = new HashTable<>(10);

        hashTable.add("Петров", new Person("Иван", "Петров"));
        hashTable.add("Иванов", new Person("Вася", "Иванов", 17));
        hashTable.add("Смирнова", new Person("Оля", "Смирнова", 21));

        hashTable.find("Петров").view();
        hashTable.find("Смирнова").view();
    }
}

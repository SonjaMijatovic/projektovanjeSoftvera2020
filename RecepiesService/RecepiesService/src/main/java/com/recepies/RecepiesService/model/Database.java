package com.recepies.RecepiesService.model;

import java.io.*;

public class Database {

    private static Database instance;
    private Recepies recepies;

    public Database() {
        recepies = new Recepies();

        Medicine med1 = new Medicine("Amoksicilin");
        Medicine med2 = new Medicine("Panklav");

        Patient pt1 = new Patient(1, "Jovan", "Jovanovic");

        Recepie recepie = new Recepie(pt1);

        RecepieItem item1 = new RecepieItem(med1, 5);
        RecepieItem item2 = new RecepieItem(med2, 6);

        recepie.getItems().add(item1);
        recepie.getItems().add(item2);

        recepies.getRecepies().add(recepie);

        save();

        load();
    }

    public Recepies getRecepies() {
        return recepies;
    }

    public void setRecepies(Recepies recepies) {
        this.recepies = recepies;
    }

    public static Database getInstance() {
        if(instance == null) {
            instance = new Database();
        }

        return instance;
    }

    public void load() {

        try {
            FileInputStream fileInputStream
                    = new FileInputStream("data.ser");
            ObjectInputStream objectInputStream
                    = new ObjectInputStream(fileInputStream);
            recepies = (Recepies) objectInputStream.readObject();
            objectInputStream.close();
        } catch (IOException | ClassNotFoundException e) {
            e.printStackTrace();
        }
    }

    public void save() {

        try {
            FileOutputStream fout = new FileOutputStream("data.ser");
            ObjectOutputStream oos = new ObjectOutputStream(fout);
            oos.writeObject(recepies);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}

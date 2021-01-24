package com.recepies.RecepiesService.model;

import com.fasterxml.jackson.core.JsonParser;
import com.fasterxml.jackson.databind.ObjectMapper;

import java.io.*;
import java.util.ArrayList;

public class Database {

    private static Database instance;
    private Recepies recepies;

    public Database() {
        recepies = new Recepies();

        Medicine med1 = new Medicine("Med 1");
        Medicine med2 = new Medicine("Med 2");

        Patient pt1 = new Patient(1, "firstName", "lastName");

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

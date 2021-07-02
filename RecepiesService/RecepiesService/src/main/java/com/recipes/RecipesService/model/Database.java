package com.recipes.RecipesService.model;

import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;

public class Database {

    private static Database instance;
    private Recipes recipes;

    public Database() {
       setup();
       save();
       load();
        
    }
    
    private void setup() {
    	 recipes = new Recipes();

         Medicine medicine = new Medicine("Amoksicilin");

         Patient patient = new Patient(1, "Jovan", "Jovanovic");

         Recipe recepie = new Recipe(patient);

         RecipeItem item1 = new RecipeItem(medicine, 2);
         
         recepie.getItems().add(item1);

         recipes.getRecepies().add(recepie);
    }

    public Recipes getAll() {
        return recipes;
    }

    public void setRecepies(Recipes recepies) {
        this.recipes = recepies;
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
            recipes = (Recipes) objectInputStream.readObject();
            objectInputStream.close();
        } catch (IOException | ClassNotFoundException e) {
            e.printStackTrace();
        }
    }

    public void save() {

        try {
            FileOutputStream fout = new FileOutputStream("data.ser");
            ObjectOutputStream oos = new ObjectOutputStream(fout);
            oos.writeObject(recipes);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
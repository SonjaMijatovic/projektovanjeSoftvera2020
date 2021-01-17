package com.main.app.domain.model.user;

import com.main.app.domain.dto.UserDTO;
import com.main.app.domain.model.AbstractEntity;
import com.main.app.domain.model.Clinic;
import com.main.app.enums.Role;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import javax.persistence.*;
import javax.validation.constraints.NotNull;
import java.time.Instant;


/**
 * The user entity representing all users of the system.
 */
@Entity
@NoArgsConstructor
@Getter
@Setter
public class User extends AbstractEntity {

    @NotNull
    private String password;

    @NotNull
    private String email;

    @NotNull
    private String name;

    @NotNull
    private String surname;

    private String resetToken;

    private Instant resetTokenExpirationDate;

    private boolean registrationConfirmed;

    private String registrationToken;

    private String address;

    private String city;

    private String country;

    private String phoneNumber;

    private String jbo;

    @Enumerated(EnumType.STRING)
    private Role role;

    @ManyToOne
    private Clinic clinic;

    public User(@NotNull String password, @NotNull String email, @NotNull String name, @NotNull String surname) {
        this.password = password;
        this.email = email;
        this.name = name;
        this.surname = surname;
        this.registrationConfirmed = false;
    }

    public User(UserDTO user) {
        this.id = user.getId();
        this.email = user.getEmail();
        this.role = user.getRole();
        this.name = user.getName();
        this.password = user.getPassword();
        this.surname = user.getSurname();
        this.address = user.getAddress();
        this.country = user.getCountry();
        this.phoneNumber = user.getPhoneNumber();
        this.jbo = user.getJbo();
        this.city = user.getCity();
    }
}
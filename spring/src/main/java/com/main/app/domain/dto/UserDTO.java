package com.main.app.domain.dto;


import com.main.app.domain.model.user.User;
import com.main.app.enums.Role;

import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@NoArgsConstructor
@Getter
@Setter
public class UserDTO {

    private Long id;
    private String email;
    private Role role;
    private String password;
    private String surname;
    private String name;
    private String address;
    private String city;
    private String country;
    private String phoneNumber;
    private String jbo;

    public UserDTO(User user) {
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

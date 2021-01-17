package com.main.app.controller;

import com.main.app.domain.dto.UserDTO;
import com.main.app.domain.model.user.User;
import com.main.app.service.CurrentUserService;
import com.main.app.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

/**
 * REST controller exposing API for register drivers and customers.
 *
 * URL : /user
 *
 *
 */
@RestController
@RequestMapping("/api/user")
public class UserController {


    private UserService userService;

    private CurrentUserService currentUserService;

    public static final int PASSWORD_MIN_LENGTH = 6;

    public static final int PASSWORD_MAX_LENGTH = 100;


    @Autowired
    public UserController(
            UserService userService,
            CurrentUserService currentUserService
    ) {
        this.userService = userService;
        this.currentUserService = currentUserService;
    }


    @GetMapping(path="/current")
    public ResponseEntity<UserDTO> getCurrentUser() {
        return new ResponseEntity<>(
                currentUserService.getCurrentUserDTO(),
                HttpStatus.OK
        );
    }

    @PostMapping(path="/")
    public ResponseEntity<UserDTO> register(@RequestBody UserDTO userDTO) {

        User saved = userService.register(new User(userDTO));

        if(saved == null) {
            return new ResponseEntity<>(null, HttpStatus.BAD_REQUEST);
        }

        return new ResponseEntity<>(new UserDTO(saved), HttpStatus.OK);
    }

    @PostMapping(path="/activate/{token}")
    public ResponseEntity<UserDTO> activate(@PathVariable String token) {

        if(!userService.aktivate(token))
        {
            return new ResponseEntity<>(null, HttpStatus.BAD_REQUEST);
        }

        return new ResponseEntity<>(null, HttpStatus.OK);
    }

    @PostMapping(path="/edit")
    public ResponseEntity<UserDTO> editUser(@RequestBody UserDTO userDTO) {

        User user = currentUserService.getCurrentUser().get();
        user.setName(userDTO.getName());
        user.setSurname(userDTO.getSurname());
        user.setAddress(userDTO.getAddress());
        user.setCity(userDTO.getCity());
        user.setCountry(userDTO.getCountry());
        user.setPhoneNumber(userDTO.getPhoneNumber());

        User saved = userService.editProfile(user);

        return new ResponseEntity<>(new UserDTO(saved), HttpStatus.OK);
    }
}

package com.main.app.service;

import com.main.app.config.SecurityUtils;
import com.main.app.domain.model.user.User;
import com.main.app.enums.Role;
import com.main.app.repository.user.UserRepository;
import com.main.app.service.email.RegistrationEmailService;
import com.main.app.staticData.StaticData;
import com.main.app.util.RandomStringGenerator;
import com.main.app.util.UserUtil;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Service;

import java.util.Optional;

/**
 * The implementation of the service used for management of the User data.
 *
 *
 */
@Service
public class UserServiceImpl implements UserService {

    private UserRepository userRepository;

    private CurrentUserService currentUserService;
    private RegistrationEmailService registrationEmailService;

    @Value("${spring.deeplink}")
    private String deeplinkUrl;

    @Value("${spring.mail.username}")
    private String emailFrom;

    @Autowired
    public UserServiceImpl(
            UserRepository repository,
            CurrentUserService currentUserService,
            RegistrationEmailService registrationEmailService
    ) {
        this.userRepository = repository;
        this.currentUserService = currentUserService;
        this.registrationEmailService = registrationEmailService;
    }

    public Optional<User> getCurrentUser() {
        Optional<String> username = SecurityUtils.getCurrentUserLogin();

        return this.userRepository.findOneByEmail(username.get());
    }

    @Override
    public Optional<User> findByEmail(String email) {
        return userRepository.findOneByEmail(email);
    }


    public Optional<User> findById(Long id) {
        return userRepository.findOneById(id);
    }


    public User save(User user) {
        return userRepository.save(user);
    }

    public User editProfile(User user) {
        return userRepository.save(user);
    }

    @Override
    public User register(User user) {

        Optional<User> databaseUser = userRepository.findOneByEmail(user.getEmail());

        if(databaseUser.isPresent()) {
            return null;
        }

        user.setRegistrationToken(RandomStringGenerator.generateRandomString(50));
        user.setRole(Role.PATIENT);
        user.setPassword(UserUtil.encriptUserPassword(user.getPassword()));

        User savedUser = userRepository.save(user);

        registrationEmailService.sendEmail(
                deeplinkUrl,
                "?registrationToken=" + savedUser.getRegistrationToken(),
                emailFrom,
                savedUser.getEmail(),
                StaticData.URL_PART_Deliverer
        );

        return savedUser;
    }

    public boolean aktivate(String token) {

        Optional<User> databaseUser = userRepository.findOneByRegistrationToken(token);

        if(!databaseUser.isPresent()) {
            return false;
        }

        User user = databaseUser.get();
        user.setRegistrationConfirmed(true);
        userRepository.save(user);

        return true;
    }
}

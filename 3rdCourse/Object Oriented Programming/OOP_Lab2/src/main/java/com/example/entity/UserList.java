package com.example.entity;
import java.util.ArrayList;
import java.util.List;

public class UserList {

        private final List<User> users = new ArrayList<>();

        public User getById(int id) {

            User result = new User();
            result.setId(-1);

            for (User user : users) {
                if (user.getId() == id) {
                    result = user;
                }
            }

            return result;
        }

        public User getUserByLoginPassword(final String login, final String password) {

            User result = new User();
            result.setId(-1);

            for (User user : users) {
                if (user.getLogin().equals(login) && user.getPassword().equals(password)) {
                    result = user;
                }
            }

            return result;
        }

        public boolean add(final User user) {

            for (User u : users) {
                if (u.getLogin().equals(user.getLogin()) && u.getPassword().equals(user.getPassword())) {
                    return false;
                }
            }

            return users.add(user);
        }

        public User.Role getRoleByLoginPassword(final String login, final String password) {
            User.Role result = User.Role.UNKNOWN;

            for (User user : users) {
                if (user.getLogin().equals(login) && user.getPassword().equals(password)) {
                    result = user.getRole();
                }
            }

            return result;
        }

        public boolean userIsExist(final String login, final String password) {

            boolean result = false;

            for (User user : users) {
                if (user.getLogin().equals(login) && user.getPassword().equals(password)) {
                    result = true;
                    break;
                }
            }

            return result;
        }

}

import { observer } from "mobx-react-lite";
import React from "react";
import { Link, NavLink } from "react-router-dom";
import {
  Button,
  Container,
  Dropdown,
  DropdownItem,
  DropdownMenu,
  Image,
  Menu,
  MenuItem,
} from "semantic-ui-react";
import { useStore } from "../stores/store";

export default observer(function NavBar() {
  const { userStore } = useStore();
  const { logout, user } = userStore;
  return (
    <Menu inverted fixed="top">
      <Container>
        <MenuItem as={NavLink} to="/" exact header>
          <img
            src="assets/logo.png"
            alt="logo"
            style={{ marginRight: "10px" }}
          />
          Hireling
        </MenuItem>

        {user && (
          <>
            <MenuItem as={NavLink} to="/calisanlar" name="Calisanlar" />

            <MenuItem as={NavLink} to="/calisanEkle">
              <Button positive content="Çalışan Ekle" />
            </MenuItem>
            <MenuItem position="right">
              <Image
                src={user?.Image || "/assets/user.png"}
                avatar
                spaced="right"
              />
              <Dropdown pointing="top left" text={user?.DisplayName}>
                <DropdownMenu>
                  <Dropdown.Item
                    as={Link}
                    to={`/profile/${user?.UserName}`}
                    text="Profilim"
                    icon="user"
                  ></Dropdown.Item>
                  <Dropdown.Item
                    onClick={logout}
                    to="/"
                    text="Çıkış Yap"
                    icon="power"
                  ></Dropdown.Item>
                </DropdownMenu>
              </Dropdown>
            </MenuItem>
          </>
        )}
      </Container>
    </Menu>
  );
});

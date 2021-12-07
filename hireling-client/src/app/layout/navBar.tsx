import React from "react";
import { NavLink } from "react-router-dom";
import { Button, Container, Menu, MenuItem } from "semantic-ui-react";

export default function NavBar() {
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
        <MenuItem as={NavLink} to="/calisanlar" name="Calisanlar" />

        <MenuItem as={NavLink} to="/calisanEkle">
          <Button positive content="Çalışan Ekle" />
        </MenuItem>
      </Container>
    </Menu>
  );
}

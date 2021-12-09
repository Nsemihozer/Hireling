import React from "react";
import Calendar from "react-calendar";
import { Header, Menu, MenuItem } from "semantic-ui-react";

export default function CalisanFilter() {
  return (
    <>
      <Menu vertical size="large" style={{ width: "100%", marginTop: 25 }}>
        <Header icon="filter" attached color="teal" content="Filtreler" />
        <MenuItem content="Tüm Çalışanlar" />
        <MenuItem content="Tüm Çalışanlar" />
        <MenuItem content="Tüm Çalışanlar" />
      </Menu>
      <Header />
      <Calendar></Calendar>
    </>
  );
}

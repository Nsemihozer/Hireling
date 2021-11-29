import React, { useEffect, useState } from "react";
import logo from "./logo.svg";
import "./App.css";
import axios from 'axios';
import { Header, List } from "semantic-ui-react";
function App() {

const [calisanlar,setCalisanlar]=useState([]);

useEffect(()=>{
  axios.get('http://localhost:5000/api/calisanlar').then(response => {
    console.log(response);
    setCalisanlar(response.data);
  })
}, [])

  return (
    <div className="App">
      <Header as='h2' icon='users' content='Hireling' />
      
          <List>
          {calisanlar.map((calisan : any)=>(
          <List.Item key={calisan.CalisanID}>{calisan.Adi}</List.Item>
          ))}
          </List>

    </div>
  );
}

export default App;

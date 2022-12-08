import logo from './logo.svg';
import './App.css';

import React, {userState, useEffect, useState} from 'react'
import api from './Services/api'




export default function App()
{
  const [mensagens, setMensagens] = useState([]);

  useEffect(() =>{
    api.post('List').then(({data}) =>
    {
      setMensagens(data)
    })
  })

  return (
<div className="App">
<header className= "App-header">
{mensagens.map(item =>
(
<div key={item.id}>{item.id} - {item.titulo}</div>
)
)}
</header>
</div>
  );
}

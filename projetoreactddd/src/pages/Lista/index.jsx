
import "../../App.css";
import { Link } from "react-router-dom";

import React, { userState, useEffect, useState } from "react";
import api from "../../Services/api.js";

export const Lista = () => {
  const [mensagens, setMensagens] = useState([]);

  useEffect(() => {
    api.post("List").then(({ data }) => {
      setMensagens(data);
    })
  })

  return (
    <div>

      <div className="navbar">
        <Link className="btn-criar" to="/cadastro">
          Criar Mensagem
        </Link>
      </div>

      <div className="container">
        {mensagens.map(item => (
          <div className="container-mensagem">
            <div className='seta-mensagem'> </div>
              <div className="base-mensagem" key={item.Id}>{item.id} - {item.titulo} </div>
          <Link className="btn-editar" 
          to={{pathname:"edicao/"+ item.id}}>
            Editar</Link>
          </div>
        ))}
      </div>

    </div>
  );
}


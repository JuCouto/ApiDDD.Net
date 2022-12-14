import "../../App.css";
import { Link, useNavigate } from "react-router-dom";

import React, { useEffect, useState } from "react";
import api from "../../Services/api.js";

export const Edicao = () =>{

    let navigate = useNavigate();

    const [titulo, setTitulo] = useState(""); // para iniciar vazio

    const handleSubmit = async (e) =>
    {
        console.log("ola")
        e.preventDefault();
        
        const data = {
            "titulo" : titulo,
            "ativo": false,
            "dataCadastro": "2022-12-09T16:30:24.5805304",
            "dataAlteração": "2022-12-09T16:30:26.5805304",
            "userId": "93112453-6095-4910-9f40-5587f78d429f"
        };console.log(data);
        
         await api.post("/Add", data);
        alert();

        alert("Mensagem criada com sucesso");
        setTitulo(""); // para limpar no final
        navigate('/'); // vai buscar a rota criada no path do routes.
    };

    return (
        <div className="container">
                <h1 className='titulo'>Cadastro</h1>
                <form onSubmit={handleSubmit}>
                    <input className="input-text" type="text" value={titulo}
                    onChange={(e) => setTitulo(e.target.value)}/>
                     <button className="btn-criar" type='submit'>
                    Enviar Mensagem
                </button>
                <Link className="btn-voltar" to='/'>Voltar</Link>
                </form>

               
        </div>
    );

}
import "../../App.css";
import { Link, useNavigate, useParams } from "react-router-dom";

import React, { useEffect, useState } from "react";
import api from "../../Services/api.js";

export const Deletar = () =>{

    let navigate = useNavigate();
    const [titulo, setTitulo] = useState(""); // para iniciar vazio
    const [mensagem, setMensagem] = useState({}); // variavel para guardar a data que está vindo da api

    const{id} = useParams(); // vai mapear se está usando algum parametro e vai mapear para dentro da variável.

    useEffect(() => {

        const param = {
            "id":id,
            "titulo" : titulo,
            "ativo": false,
            "dataCadastro": "2022-12-09T16:30:24.5805304",
            "dataAlteração": "2022-12-09T16:30:26.5805304",
            "userId":"93112453-6095-4910-9f40-5587f78d429f"
        };


        // Nome do método que está na api
        api.post('GetEntityById', param).then(({ data }) => {
          setMensagem(data); // pega o objeto q veo do BD e guarda aqui
          setTitulo(data.titulo);
        })
      },{}) // {} inicia como objeto vazio, para poder ser editado

    const handleSubmit = async (e) =>
    {
        e.preventDefault();
        
        const data = {
            "id": mensagem.id,
            "titulo" : titulo,
            "ativo": mensagem.ativo,
            "dataCadastro": mensagem.dataCadastro,
            "dataAlteracao": mensagem.dataAlteracao,
            "userId": mensagem.userId
        };
        
         await api.delete("/Delete/"+ data.id);
        alert();

        alert("Mensagem deletada com sucesso");
        setTitulo(""); // para limpar no final
        navigate('/Lista'); // vai buscar a rota criada no path do routes.
    };

    return (
        <div className="container">
                <h1 className='titulo'>Deseja realmente deletar a mensagem?</h1>

                <form onSubmit={handleSubmit}>
                    <input className="input-text" type="text" value={titulo}
                    onChange={(e) => setTitulo(e.target.value)} readOnly/>

                     <button className="btn-excluir" type='submit'>
                    Deletar
                </button>

                <Link className="btn-voltar" to='/Lista'>Cancelar</Link>
                </form>

               
        </div>
    );

}
import {BrowserRouter as Router, Routes, Route} from 'react-router-dom';
import {Lista} from "../pages/Lista";
import { Cadastro } from '../pages/Cadastro';
import { Edicao } from '../pages/Edicao';
import { Deletar } from '../pages/Deletar';

export const AppRouter = () =>{
    return (
        <Router>
            <Routes>
                <Route path="/Cadastro" element={<Cadastro/>}/>
                <Route path="/Lista" element={<Lista/>}/>
                <Route path="/Edicao/:id" element={<Edicao/>}/>
                <Route path="/Deletar/:id" element={<Deletar/>}/>
            </Routes>
        </Router>
    );
}
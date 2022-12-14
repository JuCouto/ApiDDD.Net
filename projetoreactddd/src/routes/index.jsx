import {BrowserRouter as Router, Routes, Route} from 'react-router-dom';
import {Lista} from "../pages/Lista";
import { Cadastro } from '../pages/Cadastro';
import { Edicao } from '../pages/Edicao';

export const AppRouter = () =>{
    return (
        <Router>
            <Routes>
                <Route path="/Cadastro" element={<Cadastro/>}/>
                <Route path="/" element={<Lista/>}/>
                <Route path="/Edicao/:id" element={<Edicao/>}/>
            </Routes>
        </Router>
    );
}
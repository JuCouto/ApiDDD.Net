import {BrowserRouter as Router, Routes, Route} from 'react-router-dom';
import {Lista} from "../pages/Lista";
import { Cadastro } from '../pages/Cadastro';

export const AppRouter = () =>{
    return (
        <Router>
            <Routes>
                <Route path="/Cadastro" element={<Cadastro/>}/>
                <Route path="/" element={<Lista/>}/>
            </Routes>
        </Router>
    );
}
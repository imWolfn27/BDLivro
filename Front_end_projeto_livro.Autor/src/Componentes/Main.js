import React from "react";
import { Routes, Route } from "react-router-dom";
import ShowLivros from "./Components/ShowLivros";
import AddLivro from "./Components/Add/AddLivro";
import AddAutor from "./Components/Add/AddAutor";
import EditLivro from "./Components/Edit/EditLivro";
import EditAutor from "./Components/Edit/EditAutor";
// import SearchBar from "./Components/SearchBar";

const Main=()=>{
    return(
        <>
        <Routes>
            <Route path="/" element={<ShowLivros />}/>
            <Route path="/AddLivro" element={<AddLivro />} />
            <Route path="/AddAutor" element={<AddAutor />} />
            ;<Route path="/EditLivro/:id" element={<EditLivro />} />
            <Route path="/EditAutor/:id" element={<EditAutor />} />
        </Routes>
        <div className="header">
            <div className="row1">
                <h1>Pesquise o seu livro...<br/>De certeza que o irá encontrar!</h1>
            </div>
            <div className="row2">
                <h2>Pesquise!</h2>
                <div className="searchISBN">
                    <input type="text" placeholder="Coloque o ISBN do livro que deseja encontrar!"/>
                </div>
                <div className="searchAutor">
                    <input type="text" placeholder="Coloque o Autor do livro que deseja encontrar!"/>
                </div>
                <img src="./Imagens/livrologo.PNG" alt=""/>
                <button className="searchButtom"><i class="fa-solid fa-magnifying-glass"></i></button>
                
            </div>
        </div>   
        </>
    )
}

export default Main;
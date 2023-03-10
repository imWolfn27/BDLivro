import React from "react";

const Main=()=>{
    return(
        <>
        <div className="header">
            <div className="row1">
                <h1>Pesquise o seu livro...<br/>De certeza que o irá encontrar!</h1>
            </div>
            <div className="row2">
                <h2>Pesquise</h2>
                <div className="searchISBN">
                    <input type="text" placeholder="Coloque o ISBN do livro que deseja encontrar!"/>
                    <button><i class="fa-solid fa-magnifying-glass"></i></button>
                </div>
                <div className="searchNome">
                    <input type="text" placeholder="Coloque o Nome do livro que deseja encontrar!"/>
                    <button><i class="fa-solid fa-magnifying-glass"></i></button>
                </div>
                <div className="searchAutor">
                    <input type="text" placeholder="Coloque o Nome do Autor do livro que deseja encontrar!"/>
                    <button><i class="fa-solid fa-magnifying-glass"></i></button>
                </div>
                <img src="./Imagens/livrologo.PNG" alt=""/>
            </div>
        </div>
        </>
    )
}

export default Main;
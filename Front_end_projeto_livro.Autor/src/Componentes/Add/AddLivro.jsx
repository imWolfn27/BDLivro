import React, { useState } from "react";
import axios from "axios";
import { Link, useNavigate } from "react-router-dom";

export default function AddLivro() {
  const [livro, setLivro] = useState({
    nomeLivro: "",
    isbn: "",
    precoLivro: "",
    IDAutor: "",
  });
  const navigate = useNavigate();

  const saveLivro = async (e) => {
    e.preventDefault();
    // console.log(livro);
    await axios.post("https://localhost:7189/api/Livro", {
      nomeLivro: livro.nomeLivro,
      isbn: livro.isbn,
      precoLivro: livro.precoLivro,
      IDAutor: livro.AutorId
    });
    navigate("/");
  };

  function upNomeLivro(evento) {
    setLivro({ ...livro, nomeLivro: evento.target.value });
  }

  function upISBN(evento) {
    setLivro({ ...livro, isbn: evento.target.value });
  }

  function upPrecoLivro(evento) {
    setLivro({ ...livro, precoLivro: evento.target.value });
  }

  function upAutorID(evento) {
    setLivro({ ...livro, AutorId: evento.target.value });
  }

  return (
    <div>
      <h2>Adicionar Livro</h2>
      <form onSubmit={saveLivro}>
        <div className="form-floating mb-1">
          <input
            id="nomeLivro"
            className="form-control"
            type="text"
            onChange={upNomeLivro}
            value={livro.nomeLivro}
            placeholder="Nome do Livro"
          />
          <label className="form-label" htmlFor="nomeLivro">
            Nome do Livro
          </label>
        </div>

        <div className="form-floating mb-1">
          <input
            id="isbn"
            className="form-control"
            type="text"
            onChange={upISBN}
            value={livro.isbn}
            placeholder="ISBN"
          />
          <label className="form-label" htmlFor="isbn">
            ISBN
          </label>
        </div>

        <div className="form-floating mb-1">
          <input
            id="AutorId"
            className="form-control"
            type="number"
            onChange={upAutorID}
            value={livro.AutorId}
            placeholder="Nome do Autor"
          />
          <label className="form-label" htmlFor="AutorId">
            Nome do Autor
          </label>
        </div>

        <div className="form-floating mb-1">
          <input
            id="precoLivro"
            className="form-control"
            type="number"
            onChange={upPrecoLivro}
            value={livro.precoLivro}
            placeholder="Preço do Livro"
          />
          <label className="form-label" htmlFor="precoLivro">
            Preço do Livro
          </label>
        </div>

        <div className="mt-2">
          <button className="btn btn-primary me-2" type="submit">
            Guardar
          </button>
          <Link to={"/"} className="btn btn-secondary">
            Cancelar
          </Link>
        </div>
      </form>
    </div>
  );
}

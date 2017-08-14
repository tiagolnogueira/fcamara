import { Component, OnInit } from '@angular/core';
import { IProduto } from "../models/produto.model";
import { ProdutoService } from "../services/produto.service";
import { IUsuario } from "../models/usuario.model";


@Component({    
    templateUrl: 'produtos.component.html'
})

export class ProdutosComponent implements OnInit {
    usuarioLogado: IUsuario;
    produtos: IProduto[] = [];

    constructor(private produtoService: ProdutoService) {
        this.usuarioLogado = JSON.parse(localStorage.getItem('usuarioLogado'));
    }

    ngOnInit() {
        this.loadAllUsers();
    }

   
    private loadAllUsers() {
        this.produtoService.getAll().subscribe(produtos => { this.produtos = produtos; });
    }
}
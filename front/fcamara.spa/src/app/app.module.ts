import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { LoginComponent } from "./login/login.component";
import { AuthGuard } from "./auth/auth.guard";
import { AlertService } from "./services/alert.service";
import { AuthenticationService } from "./services/authentication.service";
import { ProdutoService } from "./services/produto.service";
import { RouterModule } from "@angular/router";
import { appRoutes } from './app.route';
import { HttpModule } from "@angular/http";
import { FormsModule }    from '@angular/forms';
import { ProdutosComponent } from "./produtos/produtos.component";

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    ProdutosComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    FormsModule,
    HttpModule,
  ],
  providers: [
    AuthGuard,
    AlertService,
    AuthenticationService,
    ProdutoService,
    {
      provide: 'baseApiUrl',
      useValue: 'http://localhost:51713/api/'
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

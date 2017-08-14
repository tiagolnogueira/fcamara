import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from "./login/login.component";
import { ProdutosComponent } from "./produtos/produtos.component";
import { AuthGuard } from "./auth/auth.guard";



export const appRoutes: Routes = [
    { path: '', component: ProdutosComponent, canActivate: [AuthGuard] },
    { path: 'login', component: LoginComponent },    

    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

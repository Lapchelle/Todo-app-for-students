import React from "react";
import * as Components from './style';
import { NavLink } from "react-router-dom";


function Login() {
    const [signIn, toggle] = React.useState(true);
     return(
         <Components.Container>
             <Components.SignUpContainer signinIn={signIn}>
                 <Components.Form>
                     <Components.Title>Создать аккаунт</Components.Title>
                     <Components.Input type='text' placeholder='Имя' />
                     <Components.Input type='email' placeholder='Email' />
                     
                     <Components.Button><NavLink to="/HTMLTasks" activeStyle>
                            Задачи
                        </NavLink></Components.Button>
                 </Components.Form>
             </Components.SignUpContainer>

             <Components.SignInContainer signinIn={signIn}>
                  <Components.Form>
                      <Components.Title>Войти</Components.Title>
                      <Components.Input type='email' placeholder='Email' />
                      <Components.Input type='text' placeholder='Имя' />
                     
                      <Components.Button>Войти</Components.Button>
                  </Components.Form>
             </Components.SignInContainer>

             <Components.OverlayContainer signinIn={signIn}>
                 <Components.Overlay signinIn={signIn}>

                 <Components.LeftOverlayPanel signinIn={signIn}>
                     <Components.Title>С возвращением</Components.Title>
                     <Components.Paragraph>
                         Чтобы продолжить свою работу, введите свои данные
                     </Components.Paragraph>
                     <Components.GhostButton onClick={() => toggle(true)}>
                         Войти
                     </Components.GhostButton>
                     </Components.LeftOverlayPanel>

                     <Components.RightOverlayPanel signinIn={signIn}>
                       <Components.Title>Привет, Друг!</Components.Title>
                       <Components.Paragraph>
                           Введите свои данные, чтобы начать работу
                       </Components.Paragraph>
                           <Components.GhostButton onClick={() => toggle(false)}>
                               Зарегестрироваться
                           </Components.GhostButton> 
                     </Components.RightOverlayPanel>
 
                 </Components.Overlay>
             </Components.OverlayContainer>

         </Components.Container>
     )
}

export default Login;
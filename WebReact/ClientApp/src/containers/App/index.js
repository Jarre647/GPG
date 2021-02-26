import React, { Fragment, useEffect, useState } from 'react';
import PropTypes from 'prop-types';
import ListGrudge from '../../components/ListGrudge'
import CreateGrudge from '../../components/CreateGrudge'
//import Map from '../../components/Map'
import axios from 'axios';
import "./style.css"


function App() {
    const [grudges, setGrudges] = useState([]);
    useEffect(() => {
        axios
            .get("https://localhost:44369/api/grudges")
            .then(res => setGrudges(res.data))
    }, []);

    return (
        <Fragment>

            <div class="main">
                <h1 class="name">ABUSER.IO</h1>
                <div class="menu">
                    <a class="gpg" href="#">GPG</a>
                </div>
                <div class="menu2">
                    <a class="menu2txt" href="#"><img src="../../images/Telegram_logo.png" alt="telega"></img></a>
                    <a class="menu2txt" href="#"><img src="../../images/f.png" alt="facebook"></img></a>
                    <a class="menu2txt" href="#"><img src="../../images/twitter.png" alt="twitter"></img></a>
                </div>
            </div>
            <div class="container">
                <hr>
                </hr>
                <div class="regmenu">
                    <div class="regmenu2">
                        <a class="regmenu1txt" href="#">Sign In</a>
                        <a class="regmenu1txt" href="#">Sign Up</a>
                        <a class="regmenu2txt" href="#">DONOS NA ABUSERA</a>
                    </div>
                </div>

                <div class="middle">
                    <div class="abuser__search">
                        <div class="input">
                            <input class="input__text" placeholder="Enter name of abuser" type="text">
                            </input>
                        </div>
                        <a class="find__button" href="#">Find</a>
                    </div>
                </div>
                <div class="middlecontent">
                    <div class="abuserfounded">
                        <h1 class="abusers__top">ABUSER FOUNDED:</h1>
                        <div class="abuser__box">
                            <div class="first__abuser">
                                <p class="cardtext">Name</p>
                            </div>
                            <div class="grehi">
                                <p class="cardtext">Спулил пак и ливнул</p>
                            </div>
                        </div>
                    </div>
                    <div class="top__abusers">
                        <h1 class="abusers__top">TOP ABUSERS:</h1>
                        <div class="abuser__box">
                            <div class="first__abuser">
                                <p class="cardtext">Name</p>
                            </div>
                            <div class="grehi">
                                <p class="cardtext">Спулил пак и ливнул</p>
                            </div>
                        </div>
                        <div class="abuser__box">
                            <div class="second__abuser">
                                <p class="cardtext">Name</p>
                            </div>
                            <div class="grehi">
                                <p class="cardtext">Матерился в чат и ливнул</p>
                            </div>
                        </div>
                        <div class="abuser__box">
                            <div class="third__abuser">
                                <p class="cardtext">Name</p>
                            </div>
                            <div class="grehi">
                                <p class="cardtext">Просто ливнул спустя 10 минут</p>
                            </div>
                        </div>
                    </div>
                </div>
                <hr>
                </hr>
                <div class="middle__info">
                    <h1 class="info__heading">About Project</h1>
                    <p class="info__txt">Great Project of Grudges Изначально проект задумывался для закрепления полученных
                    навыков за последний год. Суть проекта: По мотивам одной из излюбленных игр. У одной из рас есть книга
                    записи обид, я подумал, что это может быть хорошей идеей для старта кроссплатформенного проекта, а
                    именно - создание Sql репозитория как единственного для работы с бд, к которому уже обращаются: Web сайт
                    Spa (Vue + .net core) Кроссплатформенное приложение (Ios/android)- Xamarin Чат бот для "Вконтакте" (c#)
                    Чат бот для "Телеграмм" (с#) Архитектуре: Микросервисная Дальнейшее развитие: Добавление английского и
                    китайского языка Расширение возможностей чат ботов (в планах попытка наладить самообучение, для того что
                бы боты могли сами поддерживать разговор с людьми)</p>
                </div>
                <hr>
                </hr>
            </div>

            <div class="bot__content">
                <div class="contacts">
                    <p class="contacts_text">Contact with us:</p>
                    <a href="https://vk.com/id56821661" target="blank" class="vk1">Main developer - Alexander Kirpi4nikov</a>
                    <a href="https://vk.com/ilya.dodonov" target="blank" class="vk2">Front - Ilya Dodonov</a>
                </div>
            </div>
        </Fragment>
    )
}

export default App;
import React, { Component } from 'react';

export class Home extends Component {
  displayName = Home.name

  render() {
    return (
      <div>
        <h1>Немного информации по приложению</h1>
        <ul>
            <li>Поиск идет по 2 полям - Наименование и Организация</li>
            <li>Кнопка обновить актуализирует данные(сначала запрос к hh.api, запись в бд и далее вывод в UI данных из бд + новые(если они есть))</li>
        </ul>
            <h2>Используются:</h2>
        <ul>
            <li>Postgre</li>
            <li>React</li>
            <li>EF Core</li>
            <li>Net Core</li>
            <li>Docker</li>                
        </ul>
      </div>
    );
  }
}

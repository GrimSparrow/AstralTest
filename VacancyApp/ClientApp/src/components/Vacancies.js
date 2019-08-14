import React, { Component } from "react";
import axios from "axios";

export class Vacancies extends Component {
    displayName = Vacancies.name    

    constructor() {
        super();
        this.state = {
            data: [],
            search: ""
        };
    }

    handleSearch = e => {
        this.find(e.target.value);
        this.setState({
            search: e.target.value
        });
    };

    async getData() {
        this.setState({
            data: []
        });
        const response = await axios.get("api/Vacancies/GetVacanciesFromDb");
        this.setState({
            data: response.data
        });
    }

    async find(search) {
        const response = await axios.get("api/Vacancies/FindByString?search=" + search);
        this.setState({
            data: response.data
        });
    }

    async componentDidMount() {
        this.getData();
        this.forceUpdate();
    }

    refreshData= e => {
        this.getData();
        this.forceUpdate();
};

render() {
    const { search } = this.state;

    return (
        <div className="App">
            <br />
            <div class="col-xs-8 col-lg-8">
                <input class="form-control" placeholder="Введите текст для поиска" type="text" value={search} onChange={this.handleSearch} />
            </div>
            <div class="col-xs-4 col-lg-4 text-right">
                <button onClick={this.refreshData} class="btn btn-default">Обновить</button>
            </div>
            <div class="col-xs-12 col-lg-12">
                {!this.state.data.length && <h2>ничего не найдено</h2>}
                <br />
                <table className='table table-hover table-bordered table-sm'>
                    <thead>
                        <tr>
                            <th>Название</th>
                            <th>Организация</th>
                            <th>Зарплата&nbsp;от</th>
                            <th>Зарплата&nbsp;до</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.data.map(x =>
                            <tr key={x.id}>
                                <td>{x.name}</td>
                                <td>{x.org}</td>
                                <td>{x.salaryFrom}</td>
                                <td>{x.salaryTo}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </div>
        </div>
    );
}
}

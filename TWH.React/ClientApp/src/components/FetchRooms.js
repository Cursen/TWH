import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService'

export class FetchRooms extends Component {
    static displayName = FetchRooms.Name;

    constructor(props) {
        super(props);
        this.state = { rooms: [], loading: true };
    }
    componentDidMount() {
        this.findRooms();
    }
    static renderRoomTable(rooms) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Temp. (C)</th>
                        <th>Temp. (F)</th>
                        <th>Summary</th>
                    </tr>
                </thead>
            </table>
            );
    }
    render() {
        let contents = this.state.loading ? <p><em>Loading...</em></p> :
            FetchRooms.renderRoomTable(this.state.rooms);

        return (
            <div>
                <h1 id="tabelLabel" >Room listing</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }
        async findRooms(){
            const token = await authService.getAccessToken();
            const response = await fetch('booking', {
                headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
            });
            const data = await response.json();
            this.setState({ rooms: data, loading: false });
        }
}
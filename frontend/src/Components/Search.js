import { ReactComponent as SearchSVG } from '../Images/Search.svg';
import { useState } from 'react';

function Search({ setResults, keyword, setKeyword }) {
    async function search() {
        if (!keyword) return;

        try {
            const response = await fetch(`http://localhost:5259/api/MovieDB/search?keyword=${encodeURIComponent(keyword)}`);
            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`);
            }
            const data = await response.json();
            setResults(data.results);
        } catch (error) {
            console.error('There was a problem with the fetch operation:', error);
        }
    }

    async function handleKeyDown(e) {
        if (e.key === 'Enter') {
            search();
        }
    }

    return (
        <div className="search-bar">
            <input
                type="text"
                className="search-field" id="search-field"
                placeholder="Search..."
                value={keyword}
                onChange={(e) => setKeyword(e.target.value)}
                onKeyDown={handleKeyDown}
                maxLength={100}
            />
            <button id="search-button" onClick={search}>
                <SearchSVG id="search-icon" />
            </button>
        </div>
    );
}

export default Search;

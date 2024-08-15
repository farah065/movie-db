import { ReactComponent as SearchSVG } from '../Images/Search.svg';

function Search({ search, keyword, setKeyword, setPopularLoaded, prevKeyword, setPrevKeyword, setPage, setError }) {
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

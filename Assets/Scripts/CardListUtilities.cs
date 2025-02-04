using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class CardListUtilities
{
    public static List<CardInfo> FilterList(List<CardInfo> list, CardFilterOptions filterOptions)
    {
        if (filterOptions.NoFilter) {return list;}

        List<CardInfo> filteredList = list;
        if (filterOptions.ordersIncluded.Count > 0)
        {
            filteredList = filteredList.Where(x => filterOptions.ordersIncluded.Contains(x.order)).ToList();
        }

        if (filterOptions.typesIncluded.Count > 0)
        {
            filteredList = filteredList.Where(x => filterOptions.typesIncluded.Contains(x.type)).ToList();
        }

        return filteredList;
    }
}

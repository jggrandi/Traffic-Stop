using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
    List<TabButton> tabButtons;
    // Start is called before the first frame update

    //public Color tabIdle;
    //public Color tabHover; 
    //public Color tabSelect;

    public TabButton selectedTab;

    public List<GameObject> contentPages;



    public void Subscribe(TabButton _button)
    {
        if(tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }

        tabButtons.Add(_button);
    }

    public void OnTabEnter(TabButton _button)
    {
        ResetTabs();
        if (selectedTab == null || _button != selectedTab)
        {
            //_button.background.color = tabHover;
        }
    }

    public void OnTabExit(TabButton _button)
    {
        ResetTabs();
        
    }

    public void OnTabSelected(TabButton _button)
    {
        if(selectedTab != null)
        {
            selectedTab.Deselect();
        }
        selectedTab = _button;

        selectedTab.Select();

        ResetTabs();
        //_button.background.color = tabSelect;

        int index = _button.transform.GetSiblingIndex();
        for (int i = 0; i < contentPages.Count; i++)
        {
            if(i == index)
            {
                contentPages[i].SetActive(true);
            }
            else
            {
                contentPages[i].SetActive(false);
            }
        }

    }

    public void ResetTabs()
    {
        foreach(TabButton _button in tabButtons)
        {
            if (selectedTab != null && _button == selectedTab) { continue; }
            //_button.background.color = tabIdle;
        }
    }
}
